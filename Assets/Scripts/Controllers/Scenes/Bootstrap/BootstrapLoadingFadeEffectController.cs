
using DG.Tweening;
using UnityEngine;


public class BootstrapLoadingFadeEffectController: SingletonPersistent<BootstrapLoadingFadeEffectController>
{
    [SerializeField]
    private CanvasGroup _transitionBackgroundCanvasGroup;

    [SerializeField]
    [Range(0f, 5f)]
    private float _fadeDuration;

    public static bool EndFadeIn { get; set; } = false;
    public static bool EndFadeOut { get; set; } = false;

    public void FadeIn()
    {
        EndFadeOut = false;

        _transitionBackgroundCanvasGroup.gameObject.SetActive(true);

        _transitionBackgroundCanvasGroup.DOFade(1f, _fadeDuration).OnComplete(
            () =>
            {
                EndFadeIn = true;
            }
        );
    }

    public void FadeOut()
    {
        EndFadeIn = false;

        _transitionBackgroundCanvasGroup.DOFade(0f, _fadeDuration).OnComplete(
            () =>
            {
                _transitionBackgroundCanvasGroup.gameObject.SetActive(false);
                EndFadeOut = true;
            }
        );
    }

    public void FadeAll()
    {
        _transitionBackgroundCanvasGroup.DOFade(1f, _fadeDuration).OnComplete(
            () =>
            {
                DOVirtual.DelayedCall(1f, () =>
                {
                    _transitionBackgroundCanvasGroup.DOFade(0f, _fadeDuration);
                }
                );
            }
        );
    }
}
