using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;

public enum Effect
    {
        None,               // WORKING
        Appear,             // WORKING (Try with different animators and set them correctly)
        Blush,              // WORKING
        BlushCharacters,    // WORKING (define intensity properly)
        DeflectionFont,     // WORKING
        Erase,              // WORKING (define intensity properly)
        FadeIn,             // WORKING (define alpha step properly)
        FadeInCharacters,   // WORKING (define alpha step properly)
        FadeOut,            // WORKING (define alpha step properly)
        FadeOutCharacters,  // WORKING (define alpha step properly)
        Flashing,           // WORKING
        Jitter,             // WORKING
        Palpitations,       // WORKING
        Shake,              // WORKING
        ShakeCharacters,    // WORKING
        Squash,             // WORKING
        SquashX,            // WORKING
        SquashY,            // WORKING
        Stretch,            // WORKING (define intensity properly)
        StretchX,           // WORKING (define intensity properly)
        StretchY,           // WORKING (define intensity properly)
        SwellingFont,       // WORKING (define intensity properly)
        Swing,              // WORKING
        Warp,               // WORKING
        WarpCharacters,     // WORKING
        Wave,               // WORKING
        WaveCharacters,     // WORKING    
}

public class Effects : MonoBehaviour
{
    private TMP_Text m_TextComponent;
    private RectTransform rectTransform;
    private bool hasTextChanged;
    
    private Dictionary<Effect, Coroutine> coroutines = new Dictionary<Effect, Coroutine>();
    private Dictionary<Effect, IEnumerator> enumerators = new Dictionary<Effect, IEnumerator>();

    private bool animate = true;

    public int palpitations = 2;
    public AnimationCurve VertexCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1.0f), new Keyframe(1.0f, 0));

    [Range(0.0f, 1.0f)]
    public float timeToWait = 0.0f;
    [Range(0.0f, 1.0f)]
    public float timeBetweenPalpitations = 0.1f;
    public Color blushColor = Color.red;

    
    private Color32 initialColor;
    private float initialRectX, initialRectY;
    private float duration, intensity;

    private float waveMinimum = 2f, warpMinimum = 5f;

    void Awake()
    {
        m_TextComponent = GetComponent<TMP_Text>();
        rectTransform = GetComponent<RectTransform>();
        initialColor = m_TextComponent.color;
        initialRectX = rectTransform.localScale.x;
        initialRectY = rectTransform.localScale.y;
    }

    void OnEnable()
    {
        // Subscribe to event fired when text object has been regenerated.
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
    }

    void OnDisable()
    {
        TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
    }

    public void StopEffect(Coroutine coroutine)
    {
        CoroutineStopper.Instance.StopCoroutineWithCheck(coroutine);
        coroutine = null;
    }

    public void ResetCharacters(bool fadeout)
    {
        m_TextComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = m_TextComponent.textInfo;
        Color32[] newVertexColors;

        int characterCount = textInfo.characterCount;

        for (int i = 0; i < characterCount; i++)
        {
            // Skip characters that are not visible
            if (!textInfo.characterInfo[i].isVisible) continue;

            // Get the index of the material used by the current character.
            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

            // Get the vertex colors of the mesh used by this text element (character or sprite).
            newVertexColors = textInfo.meshInfo[materialIndex].colors32;

            // Get the index of the first vertex used by this text element.
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;

            // Get the current character's alpha value.
            byte alpha = fadeout ? (byte)initialColor.a : (byte)0;

            newVertexColors[vertexIndex + 0].a = alpha;
            newVertexColors[vertexIndex + 1].a = alpha;
            newVertexColors[vertexIndex + 2].a = alpha;
            newVertexColors[vertexIndex + 3].a = alpha;

            m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
        }
    }

    public void ResetColor(bool fadeout, bool chars)
    {
        if (chars)
        {
            ResetCharacters(fadeout);
        }
        else
        {
            if (fadeout) m_TextComponent.color = initialColor;
            else m_TextComponent.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0.0f);
        }
    }

    public void ResetFontSize()
    {
        m_TextComponent.enableAutoSizing = true;
    }

    public void ResetRectTransform(bool squash, bool x, bool y)
    {
        if (squash)
            rectTransform.localScale = new Vector3(initialRectX, initialRectY, 1.0f);
        else
        {
            if (x && y)
                rectTransform.localScale = new Vector3(0.0f, 0.0f, 1.0f);
            else if (x)
                rectTransform.localScale = new Vector3(0.0f, 1.0f, 1.0f);
            else if (y)
                rectTransform.localScale = new Vector3(1.0f, 0.0f, 1.0f);
        }
    }

    private void ResetCharacterCount()
    {
        m_TextComponent.maxVisibleCharacters = m_TextComponent.textInfo.characterCount;
    }

    private void AddCoroutine(Effect effect, IEnumerator function)
    {
        try
        {
            coroutines[effect] = StartCoroutine(function);
        }
        catch
        {
            coroutines.Add(effect, StartCoroutine(function));
        }
    }

    private void AddIenumerator(Effect effect, IEnumerator function)
    {
        try
        {
            enumerators[effect] = function;
        }
        catch
        {
            enumerators.Add(effect, function);
        }
    }

    public void SetEffect(Effect[] effects, float _intensity, float _duration)
    {
        initialColor = m_TextComponent.color;
        duration = _duration;
        intensity = _intensity;
        foreach (Effect key in coroutines.Keys)
        {
            StopEffect(coroutines[key]);
            ResetCharacters(true);
            ResetColor(true, true);
            ResetFontSize();
            ResetRectTransform(true, true, true);
            ResetCharacterCount();
        }
        enumerators.Clear();

        foreach (Effect effect in effects)
        {
            switch (effect)
            {
                case Effect.None:
                    break;
                case Effect.Appear:
                    ResetCharacterCount();
                    AddIenumerator(effect, Appear());
                    break;
                case Effect.Blush:
                    ResetColor(false, false);
                    AddIenumerator(effect, Blush());
                    break;
                case Effect.BlushCharacters:
                    ResetColor(false, true);
                    AddIenumerator(effect, BlushCharacters());
                    break;
                case Effect.DeflectionFont:
                    ResetFontSize();
                    AddIenumerator(effect, DeflectionFontSize());
                    break;
                case Effect.Erase:
                    ResetColor(true, true);
                    AddIenumerator(effect, Erase());
                    break;
                case Effect.FadeIn:
                    ResetColor(false, false);
                    AddIenumerator(effect, FadeIn());
                    break;
                case Effect.FadeInCharacters:
                    ResetColor(false, true);
                    AddIenumerator(effect, FadeInCharacters());
                    break;
                case Effect.FadeOut:
                    ResetColor(true, false);
                    AddIenumerator(effect, FadeOut());
                    break;
                case Effect.FadeOutCharacters:
                    ResetColor(true, true);
                    AddIenumerator(effect, FadeOutCharacters());
                    break;
                case Effect.Flashing:
                    ResetColor(true, false);
                    AddIenumerator(effect, Flash());
                    break;
                case Effect.Jitter:
                    AddIenumerator(effect, Jitter());
                    break;
                case Effect.Palpitations:
                    ResetRectTransform(true, false, false);
                    AddIenumerator(effect, Palpitations());
                    break;
                case Effect.Shake:
                    AddIenumerator(effect, Shake(false));
                    break;
                case Effect.ShakeCharacters:
                    AddIenumerator(effect, Shake(true));
                    break;
                case Effect.Squash:
                    ResetRectTransform(true, false, false);
                    AddIenumerator(effect, Squash(true, true));
                    break;
                case Effect.SquashX:
                    ResetRectTransform(true, false, false);
                    AddIenumerator(effect, Squash(true, false));
                    break;
                case Effect.SquashY:
                    ResetRectTransform(true, false, false);
                    AddIenumerator(effect, Squash(false, true));
                    break;
                case Effect.Stretch:
                    ResetRectTransform(false, true, true);
                    AddIenumerator(effect, Stretch(true, true));
                    break;
                case Effect.StretchX:
                    ResetRectTransform(false, true, false);
                    AddIenumerator(effect, Stretch(true, false));
                    break;
                case Effect.StretchY:
                    ResetRectTransform(false, false, true);
                    AddIenumerator(effect, Stretch(false, true));
                    break;
                case Effect.SwellingFont:
                    ResetFontSize();
                    AddIenumerator(effect, SwellingFontSize());
                    break;
                case Effect.Swing:
                    AddIenumerator(effect, Swing());
                    break;
                case Effect.Warp:
                    AddIenumerator(effect, WarpText(false));
                    break;
                case Effect.WarpCharacters:
                    AddIenumerator(effect, WarpText(true));
                    break;
                case Effect.Wave:
                    AddIenumerator(effect, Wave(false));
                    break;
                case Effect.WaveCharacters:
                    AddIenumerator(effect, Wave(true));
                    break;
            }
        }

        foreach(Effect effect in enumerators.Keys)
        {
            AddCoroutine(effect, enumerators[effect]);
        }
    }

    private AnimationCurve CopyAnimationCurve(AnimationCurve curve)
    {
        AnimationCurve newCurve = new AnimationCurve();
        newCurve.keys = curve.keys;
        return newCurve;
    }

    void ON_TEXT_CHANGED(Object obj)
    {
        if (obj == m_TextComponent)
            hasTextChanged = true;
    }

    private void ApplyMatrix(Vector3[] sourceVertices, Vector3[] copyOfVertices, Matrix4x4 matrix, Vector3 center, int vertexIndex)
    {
        // Need to translate all 4 vertices of each quad to aligned with center of character.
        // This is needed so the matrix TRS is applied at the origin for each character.
        copyOfVertices[vertexIndex + 0] = sourceVertices[vertexIndex + 0] - center;
        copyOfVertices[vertexIndex + 1] = sourceVertices[vertexIndex + 1] - center;
        copyOfVertices[vertexIndex + 2] = sourceVertices[vertexIndex + 2] - center;
        copyOfVertices[vertexIndex + 3] = sourceVertices[vertexIndex + 3] - center;

        // Apply the matrix TRS to the individual characters relative to the center of the current line.
        copyOfVertices[vertexIndex + 0] = matrix.MultiplyPoint3x4(copyOfVertices[vertexIndex + 0]);
        copyOfVertices[vertexIndex + 1] = matrix.MultiplyPoint3x4(copyOfVertices[vertexIndex + 1]);
        copyOfVertices[vertexIndex + 2] = matrix.MultiplyPoint3x4(copyOfVertices[vertexIndex + 2]);
        copyOfVertices[vertexIndex + 3] = matrix.MultiplyPoint3x4(copyOfVertices[vertexIndex + 3]);

        // Revert the translation change.
        copyOfVertices[vertexIndex + 0] += center;
        copyOfVertices[vertexIndex + 1] += center;
        copyOfVertices[vertexIndex + 2] += center;
        copyOfVertices[vertexIndex + 3] += center;
    }

    IEnumerator Appear()
    {
        bool repeat = false;
        m_TextComponent.ForceMeshUpdate();
        int totalVisibleCharacters = m_TextComponent.textInfo.characterCount; // Get # of Visible Character in text object
        int counter = 0;
        int visibleCount = 0;
        while (animate)
        {
            if (visibleCount < totalVisibleCharacters || repeat)
            {
                visibleCount = counter % (totalVisibleCharacters + 1);

                m_TextComponent.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?
                counter += 1;
            }

            // Once the last character has been revealed, wait 1.0 second and start over.
            if (visibleCount >= totalVisibleCharacters)
            {
                break;
            }

            yield return new WaitForSeconds(1f / (totalVisibleCharacters / 1.5f) * intensity);
        }
    }

    IEnumerator Blush()
    {
        m_TextComponent.ForceMeshUpdate();

        Color32 c = m_TextComponent.color;
        while (!c.CompareRGB(blushColor))
        {
            c = Color.Lerp(c, blushColor, Time.deltaTime * intensity);
            m_TextComponent.color = c;
            yield return new WaitForSeconds(timeToWait);
        }
    }

    IEnumerator BlushCharacters()
    {
        m_TextComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = m_TextComponent.textInfo;
        Color32[] newVertexColors;

        int characterCount = textInfo.characterCount;

        for (int i = 0; i < characterCount; i++)
        {
            Color32 c = m_TextComponent.color;

            // Skip characters that are not visible
            if (!textInfo.characterInfo[i].isVisible) continue;

            // Get the index of the material used by the current character.
            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

            // Get the vertex colors of the mesh used by this text element (character or sprite).
            newVertexColors = textInfo.meshInfo[materialIndex].colors32;

            // Get the index of the first vertex used by this text element.
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;

            while (!c.CompareRGB(blushColor))
            {
                c = Color.Lerp(c, blushColor, intensity);
                newVertexColors[vertexIndex + 0] = c;
                newVertexColors[vertexIndex + 1] = c;
                newVertexColors[vertexIndex + 2] = c;
                newVertexColors[vertexIndex + 3] = c;
                m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
                yield return new WaitForSeconds(timeToWait);
            }
        }
    }

    IEnumerator DeflectionFontSize()
    {
        // We force an update of the text object since it would only be updated at the end of the frame. Ie. before this code is executed on the first frame.
        // Alternatively, we could yield and wait until the end of the frame when the text object will be generated.
        m_TextComponent.ForceMeshUpdate();
        var initialSize = m_TextComponent.fontSize;
        var autoSize = m_TextComponent.enableAutoSizing;
        if (autoSize)
            m_TextComponent.enableAutoSizing = false;

        TMP_TextInfo textInfo = m_TextComponent.textInfo;

        hasTextChanged = true;

        float scale = (1f / (textInfo.characterCount * 3f)) * intensity;

        for (int j = 0; j < textInfo.characterCount; j++)
        {
            if (!textInfo.characterInfo[j].isVisible)
                continue;

            while (m_TextComponent.fontSize > 0)
            {
                m_TextComponent.fontSize -= scale;
                m_TextComponent.fontSize = Mathf.Clamp(m_TextComponent.fontSize, 0, initialSize);
                yield return new WaitForSeconds(timeToWait);
            }
        }

        yield return new WaitForSeconds(timeToWait);
    }

    IEnumerator Erase()
    {
        // Need to force the text object to be generated so we have valid data to work with right from the start.
        m_TextComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = m_TextComponent.textInfo;
        Color32[] newVertexColors;

        int characterCount = textInfo.characterCount;

        while (animate)
        {
            for (int i = 0; i < characterCount; i++)
            {
                // Skip characters that are not visible
                if (!textInfo.characterInfo[i].isVisible) continue;

                // Get the index of the material used by the current character.
                int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

                // Get the vertex colors of the mesh used by this text element (character or sprite).
                newVertexColors = textInfo.meshInfo[materialIndex].colors32;

                // Get the index of the first vertex used by this text element.
                int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                // Get the current character's alpha value.
                byte alpha = (byte)Mathf.Clamp(newVertexColors[vertexIndex + 0].a - (intensity * 10), 0, 255);
                // Set new alpha values.
                newVertexColors[vertexIndex + 0].a = alpha;
                newVertexColors[vertexIndex + 1].a = alpha;
                newVertexColors[vertexIndex + 2].a = alpha;
                newVertexColors[vertexIndex + 3].a = alpha;

                // Upload the changed vertex colors to the Mesh.
                m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

                yield return new WaitForSeconds(timeToWait);
            }
        }
    }

    IEnumerator FadeIn()
    {
        m_TextComponent.ForceMeshUpdate();

        Color32 c = m_TextComponent.color;
        while (c.a < initialColor.a)
        {
            if (c.a >= initialColor.a - (intensity * 10))
                c.a = System.Convert.ToByte(initialColor.a);
            else
                c.a += System.Convert.ToByte(Mathf.Clamp(duration, 0, initialColor.a));
            m_TextComponent.color = c;
            yield return new WaitForSeconds(timeToWait);
        }
    }

    IEnumerator FadeInCharacters()
    {
        // Need to force the text object to be generated so we have valid data to work with right from the start.
        //m_TextComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = m_TextComponent.textInfo;
        Color32[] newVertexColors;

        int characterCount = textInfo.characterCount;

        for (int i = 0; i < characterCount; i++)
        {
            // Skip characters that are not visible
            if (!textInfo.characterInfo[i].isVisible) continue;

            // Get the index of the material used by the current character.
            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

            // Get the vertex colors of the mesh used by this text element (character or sprite).
            newVertexColors = textInfo.meshInfo[materialIndex].colors32;

            // Get the index of the first vertex used by this text element.
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;

            // Get the current character's alpha value.
            byte alpha = (byte)Mathf.Clamp(newVertexColors[vertexIndex + 0].a + (intensity * 10), 0, initialColor.a);

            while (alpha < 255)
            {
                // Set new alpha values.
                newVertexColors[vertexIndex + 0].a = alpha;
                newVertexColors[vertexIndex + 1].a = alpha;
                newVertexColors[vertexIndex + 2].a = alpha;
                newVertexColors[vertexIndex + 3].a = alpha;

                m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
                yield return new WaitForSeconds(timeToWait);
                alpha = (byte)Mathf.Clamp(newVertexColors[vertexIndex + 0].a + (intensity * 10), 0, initialColor.a);
            }
            yield return new WaitForSeconds(timeToWait);
        }
    }

    IEnumerator FadeOut(bool fadeIn = false)
    {
        m_TextComponent.ForceMeshUpdate();

        Color32 c = m_TextComponent.color;
        float step = CalculateStep(m_TextComponent.textInfo.characterCount);

        while (c.a > 0.0)
        {
            if (c.a <= step)
                c.a = System.Convert.ToByte(0.0f);
            else
                c.a -= System.Convert.ToByte(Mathf.Clamp(step, 0, 255));
            m_TextComponent.color = c;
            yield return new WaitForSeconds(timeToWait);
        }
        if (fadeIn)
            yield return StartCoroutine(FadeIn());
    }

    IEnumerator FadeOutCharacters(bool fadeIn = false)
    {
        // Need to force the text object to be generated so we have valid data to work with right from the start.
        m_TextComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = m_TextComponent.textInfo;
        Color32[] newVertexColors;

        int characterCount = textInfo.characterCount;

        for (int i = 0; i < characterCount; i++)
        {
            // Skip characters that are not visible
            if (!textInfo.characterInfo[i].isVisible) continue;

            // Get the index of the material used by the current character.
            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

            // Get the vertex colors of the mesh used by this text element (character or sprite).
            newVertexColors = textInfo.meshInfo[materialIndex].colors32;

            // Get the index of the first vertex used by this text element.
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;

            // Get the current character's alpha value.
            byte alpha = (byte)Mathf.Clamp(newVertexColors[vertexIndex + 0].a - (intensity * 10), 0, 255);

            while (alpha > 0)
            {
                // Set new alpha values.
                newVertexColors[vertexIndex + 0].a = alpha;
                newVertexColors[vertexIndex + 1].a = alpha;
                newVertexColors[vertexIndex + 2].a = alpha;
                newVertexColors[vertexIndex + 3].a = alpha;

                m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
                yield return new WaitForSeconds(timeToWait);
                alpha = (byte)Mathf.Clamp(newVertexColors[vertexIndex + 0].a - (intensity * 10), 0, 255);
            }
            yield return new WaitForSeconds(timeToWait);
        }
        if (fadeIn)
            yield return StartCoroutine(FadeInCharacters());
    }

    IEnumerator Flash()
    {
        m_TextComponent.ForceMeshUpdate();

        Color32 c = m_TextComponent.color;
        byte alpha = c.a;

        while (animate)
        {
            if (c.a == 0)
            {
                c.a = alpha;
            }
            else
            {
                c.a = 0;
            }
            m_TextComponent.color = c;
            yield return new WaitForSeconds((timeToWait + 0.1f) / (intensity + 0.1f));
        }
    }

    IEnumerator Jitter()
    {
        // We force an update of the text object since it would only be updated at the end of the frame. Ie. before this code is executed on the first frame.
        // Alternatively, we could yield and wait until the end of the frame when the text object will be generated.
        m_TextComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = m_TextComponent.textInfo;
        TMP_MeshInfo[] cachedMeshInfo = textInfo.CopyMeshInfoVertexData();
        Matrix4x4 matrix;

        hasTextChanged = true;

        while (animate)
        {
            // Allocate new vertices 
            if (hasTextChanged)
            {
                cachedMeshInfo = textInfo.CopyMeshInfoVertexData();
                hasTextChanged = false;
            }

            int characterCount = textInfo.characterCount;

            // If No Characters then just yield and wait for some text to be added
            if (characterCount == 0)
            {
                yield return new WaitForSeconds(0.25f);
                continue;
            }

            int lineCount = textInfo.lineCount;

            float rangeX = 0.0f, rangeY = 0.0f;
            rangeX = Random.Range(-0.5f, 0.5f) + Random.Range(-2.5f, 2.5f) * intensity;
            rangeY = Random.Range(-0.5f, 0.5f) + Random.Range(-2.5f, 2.5f) * intensity;

            // Iterate through each line of the text.
            for (int i = 0; i < lineCount; i++)
            {
                int first = textInfo.lineInfo[i].firstCharacterIndex;
                int last = textInfo.lineInfo[i].lastCharacterIndex;
                Vector3 centerOfLine = (textInfo.characterInfo[first].bottomLeft + textInfo.characterInfo[last].topRight) / 2;

                for (int j = first; j <= last; j++)
                {
                    if (!textInfo.characterInfo[j].isVisible)
                        continue;

                    int materialIndex = textInfo.characterInfo[j].materialReferenceIndex;
                    int vertexIndex = textInfo.characterInfo[j].vertexIndex;
                    Vector3[] sourceVertices = cachedMeshInfo[materialIndex].vertices;
                    Vector3[] copyOfVertices = textInfo.meshInfo[materialIndex].vertices;
                    matrix = Matrix4x4.TRS(new Vector3(rangeX, rangeY, 0.0f), Quaternion.identity, Vector3.one);

                    ApplyMatrix(sourceVertices, copyOfVertices, matrix, centerOfLine, vertexIndex);
                }

                yield return new WaitForSeconds(timeToWait);
            }

            for (int i = 0; i < textInfo.meshInfo.Length; i++)
            {
                textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
                m_TextComponent.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
            }

            yield return new WaitForSeconds(timeToWait);
        }
    }

    IEnumerator Palpitations()
    {
        m_TextComponent.ForceMeshUpdate();
        TMP_TextInfo textInfo = m_TextComponent.textInfo;
        int characterCount = textInfo.characterCount;

        Vector3 localScale = rectTransform.localScale;
        Vector3 initialScale = localScale;
        float scale = intensity / 20f;
        float finalX = intensity + (3f / characterCount);   // + 0.5f if leaving the balloon doesn't matter
        float finalY = intensity + (3f / characterCount);   // + 0.5f if leaving the balloon doesn't matter

        while (animate)
        {
            for (int i = 0; i < palpitations; i++)
            {
                while (localScale.x != finalX && localScale.y != finalY)
                {
                    localScale.x += scale;
                    localScale.y += scale;
                    localScale.x = Mathf.Clamp(localScale.x, initialScale.x, finalX);
                    localScale.y = Mathf.Clamp(localScale.y, initialScale.y, finalY);
                    rectTransform.localScale = localScale;
                    yield return null;
                }

                yield return new WaitForSeconds(timeBetweenPalpitations);

                while (localScale.x != initialScale.x && localScale.y != initialScale.y)
                {
                    localScale.x -= scale;
                    localScale.y -= scale;
                    localScale.x = Mathf.Clamp(localScale.x, initialScale.x, finalX);
                    localScale.y = Mathf.Clamp(localScale.y, initialScale.y, finalY);
                    rectTransform.localScale = localScale;
                    yield return null;
                }

                yield return new WaitForSeconds(timeBetweenPalpitations);
            }

            yield return new WaitForSeconds((timeToWait + 0.1f) * 2);
        }
    }

    IEnumerator Shake(bool characters)
    {
        // We force an update of the text object since it would only be updated at the end of the frame. Ie. before this code is executed on the first frame.
        // Alternatively, we could yield and wait until the end of the frame when the text object will be generated.
        m_TextComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = m_TextComponent.textInfo;
        Matrix4x4 matrix;
        TMP_MeshInfo[] cachedMeshInfo = textInfo.CopyMeshInfoVertexData();

        hasTextChanged = true;

        while (animate)
        {
            // Allocate new vertices 
            if (hasTextChanged)
            {
                cachedMeshInfo = textInfo.CopyMeshInfoVertexData();
                hasTextChanged = false;
            }

            int characterCount = textInfo.characterCount;

            // If No Characters then just yield and wait for some text to be added
            if (characterCount == 0)
            {
                yield return new WaitForSeconds(0.25f);
                continue;
            }

            int lineCount = textInfo.lineCount;

            // Iterate through each line of the text.
            for (int i = 0; i < lineCount; i++)
            {

                int first = textInfo.lineInfo[i].firstCharacterIndex;
                int last = textInfo.lineInfo[i].lastCharacterIndex;

                // Determine the center of each line
                Vector3 centerOfLine = (textInfo.characterInfo[first].bottomLeft + textInfo.characterInfo[last].topRight) / 2;
                Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(-1.0f, 1.0f) + Random.Range(-2.5f, 2.5f) * intensity);

                // Iterate through each character of the line.
                for (int j = first; j <= last; j++)
                {
                    // Skip characters that are not visible and thus have no geometry to manipulate.
                    if (!textInfo.characterInfo[j].isVisible)
                        continue;

                    // Get the index of the material used by the current character.
                    int materialIndex = textInfo.characterInfo[j].materialReferenceIndex;

                    // Get the index of the first vertex used by this text element.
                    int vertexIndex = textInfo.characterInfo[j].vertexIndex;

                    // Get the vertices of the mesh used by this text element (character or sprite).
                    Vector3[] sourceVertices = cachedMeshInfo[materialIndex].vertices;
                    Vector3[] copyOfVertices = textInfo.meshInfo[materialIndex].vertices;

                    if (!characters)
                    {
                        // Setup the matrix rotation.
                        matrix = Matrix4x4.TRS(Vector3.one, rotation, Vector3.one);
                        ApplyMatrix(sourceVertices, copyOfVertices, matrix, centerOfLine, vertexIndex);
                    }
                    else
                    {
                        Vector3 charMidBasline = (sourceVertices[vertexIndex + 0] + sourceVertices[vertexIndex + 2]) / 2;
                        matrix = Matrix4x4.TRS(Vector3.one, rotation, Vector3.one);
                        ApplyMatrix(sourceVertices, copyOfVertices, matrix, charMidBasline, vertexIndex);
                    }
                }
            }

            // Push changes into meshes
            for (int i = 0; i < textInfo.meshInfo.Length; i++)
            {
                textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
                m_TextComponent.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
            }

            yield return new WaitForSeconds(timeToWait);
        }
    }

    IEnumerator Squash(bool x, bool y)
    {
        m_TextComponent.ForceMeshUpdate();
        TMP_TextInfo textInfo = m_TextComponent.textInfo;
        int characterCount = textInfo.characterCount;

        float scale = intensity / (50.0f * characterCount);
        Vector3 localScale = rectTransform.localScale;

        bool condition = y ? rectTransform.localScale.y > 0.0f : x ? rectTransform.localScale.x > 0.0f : (x && y) ? (rectTransform.localScale.y > 0.0f && rectTransform.localScale.x > 0.0f) : false;

        while (condition)
        {
            localScale.y -= y ? scale : 0;
            localScale.x -= x ? scale : 0;
            localScale.y = Mathf.Clamp01(localScale.y);
            localScale.x = Mathf.Clamp01(localScale.x);
            rectTransform.localScale = localScale;
            yield return new WaitForSeconds(timeToWait);
            condition = y ? rectTransform.localScale.y > 0.0f : x ? rectTransform.localScale.x > 0.0f : (x && y) ? (rectTransform.localScale.y > 0.0f && rectTransform.localScale.x > 0.0f) : false;
        }
    }

    IEnumerator Stretch(bool x, bool y)
    {
        m_TextComponent.ForceMeshUpdate();
        TMP_TextInfo textInfo = m_TextComponent.textInfo;
        int characterCount = textInfo.characterCount;

        float scale = 0.00005f / (intensity / (50.0f * characterCount / 2));
        Vector3 localScale = rectTransform.localScale;

        bool condition = y ? rectTransform.localScale.y < 1.0f : x ? rectTransform.localScale.x < 1.0f : x && y ? rectTransform.localScale.y < 1.0f && rectTransform.localScale.x < 1.0f : false;

        while (condition)
        {
            localScale.y += y ? scale : 0;
            localScale.x += x ? scale : 0;
            localScale.y = Mathf.Clamp01(localScale.y);
            localScale.x = Mathf.Clamp01(localScale.x);
            rectTransform.localScale = localScale;
            yield return new WaitForSeconds(timeToWait);
            condition = y ? rectTransform.localScale.y < 1.0f : x ? rectTransform.localScale.x < 1.0f : x && y ? rectTransform.localScale.y < 1.0f && rectTransform.localScale.x < 1.0f : false;
        }
    }

    IEnumerator SwellingFontSize()
    {
        // We force an update of the text object since it would only be updated at the end of the frame. Ie. before this code is executed on the first frame.
        // Alternatively, we could yield and wait until the end of the frame when the text object will be generated.
        m_TextComponent.ForceMeshUpdate();
        var autoSize = m_TextComponent.enableAutoSizing;
        if (autoSize)
            m_TextComponent.enableAutoSizing = false;
        var finalSize = m_TextComponent.fontSize;
        m_TextComponent.fontSize = 0;

        TMP_TextInfo textInfo = m_TextComponent.textInfo;

        hasTextChanged = true;

        float scale = 0.25f * intensity;

        for (int j = 0; j < textInfo.characterCount; j++)
        {
            if (!textInfo.characterInfo[j].isVisible)
                continue;

            while (m_TextComponent.fontSize < finalSize)
            {
                m_TextComponent.fontSize += scale;
                m_TextComponent.fontSize = Mathf.Clamp(m_TextComponent.fontSize, 0, finalSize);
                yield return new WaitForSeconds(timeToWait);
            }
        }

        yield return new WaitForSeconds(timeToWait);
        m_TextComponent.enableAutoSizing = autoSize;
    }

    IEnumerator Swing()
    {
        Matrix4x4 matrix;
        Vector3[] vertices;
        int loopCount = 0;

        float[] vertexAnimAngleRanges = new float[1024];
        float[] vertexAnimSpeeds = new float[1024];
        for (int i = 0; i < 1024; i++)
        {
            vertexAnimAngleRanges[i] = Random.Range(2f, 5f) + Random.Range(2f, 5f) * intensity;
            vertexAnimSpeeds[i] = Random.Range(0.2f, 0.5f) + Random.Range(0.2f, 0.5f) * intensity;
        }

        while (animate)
        {
            m_TextComponent.ForceMeshUpdate();
            vertices = m_TextComponent.mesh.vertices;

            int characterCount = m_TextComponent.textInfo.characterCount;

            for (int i = 0; i < characterCount; i++)
            {
                var charInfo = m_TextComponent.textInfo.characterInfo[i];

                if (!charInfo.isVisible) continue;

                int vertexIndex = charInfo.vertexIndex;

                Vector3 charMidTopLine = new Vector3((vertices[vertexIndex + 0].x + vertices[vertexIndex + 2].x) / 2, charInfo.topRight.y);


                var vertAnimAngle = Mathf.SmoothStep(-vertexAnimAngleRanges[i], vertexAnimAngleRanges[i], Mathf.PingPong(loopCount / 25f * vertexAnimSpeeds[i], 1f));
                matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, vertAnimAngle), Vector3.one);
                ApplyMatrix(vertices, vertices, matrix, charMidTopLine, vertexIndex);
            }

            loopCount++;

            for (int i = 0; i < m_TextComponent.textInfo.meshInfo.Length; i++)
            {
                m_TextComponent.textInfo.meshInfo[i].mesh.vertices = vertices;
                m_TextComponent.UpdateGeometry(m_TextComponent.textInfo.meshInfo[i].mesh, i);
            }
            yield return new WaitForSeconds(timeToWait);
        }
    }

    IEnumerator WarpText(bool characters)
    {
        VertexCurve.preWrapMode = WrapMode.Clamp;
        VertexCurve.postWrapMode = WrapMode.Clamp;

        //Mesh mesh = m_TextComponent.textInfo.meshInfo[0].mesh;

        Vector3[] vertices;
        Matrix4x4 matrix;

        m_TextComponent.havePropertiesChanged = true; // Need to force the TextMeshPro Object to be updated.
        float CurveScale = warpMinimum + intensity * 10;
        float old_CurveScale = CurveScale;
        AnimationCurve old_curve = CopyAnimationCurve(VertexCurve);

        while (animate)
        {
            CurveScale = warpMinimum + intensity * 10;

            if (!m_TextComponent.havePropertiesChanged && old_CurveScale == CurveScale && old_curve.keys[1].value == VertexCurve.keys[1].value)
            {
                yield return null;
                continue;
            }

            old_CurveScale = CurveScale;
            old_curve = CopyAnimationCurve(VertexCurve);

            m_TextComponent.ForceMeshUpdate(); // Generate the mesh and populate the textInfo with data we can use and manipulate.

            TMP_TextInfo textInfo = m_TextComponent.textInfo;
            int characterCount = textInfo.characterCount;

            if (characterCount == 0) continue;

            //vertices = textInfo.meshInfo[0].vertices;
            //int lastVertexIndex = textInfo.characterInfo[characterCount - 1].vertexIndex;

            float boundsMinX = m_TextComponent.bounds.min.x;  //textInfo.meshInfo[0].mesh.bounds.min.x;
            float boundsMaxX = m_TextComponent.bounds.max.x;  //textInfo.meshInfo[0].mesh.bounds.max.x;

            for (int i = 0; i < characterCount; i++)
            {
                if (!textInfo.characterInfo[i].isVisible)
                    continue;

                int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                // Get the index of the mesh used by this character.
                int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

                vertices = textInfo.meshInfo[materialIndex].vertices;

                // Compute the baseline mid point for each character
                Vector3 offsetToMidBaseline = new Vector2((vertices[vertexIndex + 0].x + vertices[vertexIndex + 2].x) / 2, textInfo.characterInfo[i].baseLine);

                // Compute the angle of rotation for each character based on the animation curve
                float x0 = (offsetToMidBaseline.x - boundsMinX) / (boundsMaxX - boundsMinX); // Character's position relative to the bounds of the mesh.
                float x1 = x0 + 0.0001f;
                float y0 = VertexCurve.Evaluate(x0) * CurveScale;
                float y1 = VertexCurve.Evaluate(x1) * CurveScale;

                Vector3 horizontal = new Vector3(1, 0, 0);
                Vector3 tangent = new Vector3(x1 * (boundsMaxX - boundsMinX) + boundsMinX, y1) - new Vector3(offsetToMidBaseline.x, y0);

                float dot = Mathf.Acos(Vector3.Dot(horizontal, tangent.normalized)) * 57.2957795f;
                Vector3 cross = Vector3.Cross(horizontal, tangent);
                float angle = cross.z > 0 ? dot : 360 - dot;

                matrix = Matrix4x4.TRS(new Vector3(0, y0, 0), Quaternion.Euler(0, 0, angle), Vector3.one);

                // Apply offset to adjust our pivot point.
                ApplyMatrix(vertices, vertices, matrix, offsetToMidBaseline, vertexIndex);

                if (characters)
                {
                    m_TextComponent.UpdateVertexData();
                    yield return new WaitForSeconds(timeToWait);
                }
            }

            if (!characters)
            {
                // Upload the mesh with the revised information
                m_TextComponent.UpdateVertexData();
                yield return new WaitForSeconds(timeToWait);
            }
        }
    }

    IEnumerator Wave(bool characters)
    {
        VertexCurve.preWrapMode = WrapMode.Loop;
        VertexCurve.postWrapMode = WrapMode.Loop;

        Vector3[] vertices;
        Matrix4x4 matrix;
        float CurveScale = waveMinimum + intensity * 10;

        while (animate)
        {
            m_TextComponent.ForceMeshUpdate();

            TMP_TextInfo textInfo = m_TextComponent.textInfo;
            int characterCount = textInfo.characterCount;

            float boundsMinX = m_TextComponent.bounds.min.x;
            float boundsMaxX = m_TextComponent.bounds.max.x;

            for (int i = 0; i < characterCount; i++)
            {
                if (!textInfo.characterInfo[i].isVisible)
                    continue;

                int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                // Get the index of the mesh used by this character.
                int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

                vertices = textInfo.meshInfo[materialIndex].vertices;

                // Compute the baseline mid point for each character
                Vector3 offsetToMidBaseline = new Vector2((vertices[vertexIndex + 0].x + vertices[vertexIndex + 2].x) / 2, textInfo.characterInfo[i].baseLine);

                // Compute the angle of rotation for each character based on the animation curve
                float x0 = (offsetToMidBaseline.x - boundsMinX) / (boundsMaxX - boundsMinX); // Character's position relative to the bounds of the mesh.
                float x1 = x0 + 0.0001f;
                float y0 = VertexCurve.Evaluate(x0 + Time.time) * CurveScale;
                float y1 = VertexCurve.Evaluate((characters ? x1 : x0) + Time.time) * CurveScale;

                Vector3 horizontal = new Vector3(1, 0, 0);
                Vector3 tangent = new Vector3(x1 * (boundsMaxX - boundsMinX) + boundsMinX, y1) - new Vector3(offsetToMidBaseline.x, y0);

                float dot = Mathf.Acos(Vector3.Dot(horizontal, tangent.normalized)) * 57.2957795f;
                Vector3 cross = Vector3.Cross(horizontal, tangent);
                float angle = cross.z > 0 ? dot : 360 - dot;

                matrix = Matrix4x4.TRS(new Vector3(0, y0, 0), Quaternion.Euler(0, 0, angle), Vector3.one);

                // Apply offset to adjust our pivot point.
                ApplyMatrix(vertices, vertices, matrix, offsetToMidBaseline, vertexIndex);
            }

            m_TextComponent.UpdateVertexData();
            yield return new WaitForSeconds(timeToWait);
        }
    }

    private float CalculateStep(int characterCount)
    {
        float realIntensity = ((intensity / 2) * (Mathf.Max(0, (characterCount - 20) / 100)) + Mathf.Max(0.2f, 0.2f * (Mathf.Max(0, (characterCount - 20) / 100))));
        float realDuration = Mathf.Min(duration, (duration) - (duration - 1) * realIntensity);
        return realDuration;
    }
}