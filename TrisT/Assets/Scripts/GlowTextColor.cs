using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GlowTextColor : MonoBehaviour {
    TextMeshPro _textMeshPro;
    Color[] _color = { Color.red, Color.green, Color.yellow, Color.cyan, Color.magenta};
    public float _glowPow = 1.0f;
    public bool _setColor = true;
    public bool _up = true;
    public float _change = 0.00001f;
    public int count = 0;
    public int _colCount = 0;

    // Start is called before the first frame update
    void Start() {
        _textMeshPro = GetComponent<TextMeshPro>();
        _textMeshPro.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, _glowPow);
        _textMeshPro.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, Color.magenta);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update() {

        if (_glowPow > 0 && _glowPow <= 1) {
            if (_up == true) {
                _glowPow += _change;
            }
            if (_up == false) {
                _glowPow -= _change;
            }
        }
        if (_glowPow <= 0 && _up == false) {
            _glowPow = 0.00001f;
            if (_colCount == _color.Length) {
                _colCount = 0;
            }
            _textMeshPro.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, _color[_colCount]);
            _colCount++;
            _up = true;
        }
        if (_glowPow >= 1 && _up == true) {
            _glowPow = 0.99999f;
            _up = false;
        }

        _textMeshPro.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, _glowPow);

    }

}
