using UnityEngine;
using UnityEngine.UI;

public abstract class CustomerState : MonoBehaviour
{
    protected CustomerStateMachine stateMachine;
    protected Customer customer;

    protected Vector2 direction = Vector2.zero;

    public virtual void Enter(CustomerStateMachine stateMachine) {
        Debug.Log($"State : {this.GetType().Name}");
        this.stateMachine = stateMachine;
        customer = GetComponent<Customer>();
        customer.timer.fillAmount = 1;
    }

    public abstract void _Update();

    public abstract void Exit();

    public virtual void ShowEmoji(EmojiSO emoji) {
        //말풍선 활성화
        customer.canvas.SetActive(true);
        //말풍선에 이모지 그리기
        customer.emoji.GetComponent<Image>().sprite = GetEmojiSprite(emoji);
        customer.timer.GetComponent<Image>().sprite = GetEmojiSprite(emoji);
    }

    Sprite GetEmojiSprite(EmojiSO emoji) {
        switch (emoji.name)
        {
            case "orderwaiting":
                return DataManager.instance.emojis["orderwaiting"].GetSprite();
            case "menuwaiting":
                //주문한 메뉴 머리에 띄우기
                return customer.menu.GetSprite();
            case "enjoying":
                return DataManager.instance.emojis["enjoying"].GetSprite();
            case "angryleaving":
                return DataManager.instance.emojis["angryleaving"].GetSprite();
            default:
                Debug.LogError("일치하는 스프라이트 없음");
                return null;
        }
        Debug.LogError("일치하는 스프라이트 없음");
        return null;
    }

    public virtual void HideEmoji() {
        //말풍선 비활성화
        customer.canvas.SetActive(false);
    }

    protected bool ishori;
    protected bool isvert;

    protected void Animate() {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
            ishori = true;
            isvert = false;
            customer.animator.SetBool("ischanged", true);
        }
        if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y)) {
            ishori = false;
            isvert = true;
            customer.animator.SetBool("ischanged", true);
        }
        if (direction == Vector2.zero) {
            ishori = false;
            isvert = false;
            customer.animator.SetBool("ischanged", true);
        }

        if (ishori != customer.animator.GetBool("ishori")
            || isvert != customer.animator.GetBool("isvert")) {
            customer.animator.SetBool("ischanged", false);
        }

        customer.animator.SetBool("ishori", ishori);
        customer.animator.SetBool("isvert", isvert);
        customer.animator.SetFloat("hori", direction.x);
        customer.animator.SetFloat("vert", direction.y);
    }
}
