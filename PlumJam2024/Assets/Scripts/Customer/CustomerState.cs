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

    public virtual void ShowEmoji(Enums.Emoji emoji) {
        //말풍선 활성화
        customer.canvas.SetActive(true);
        //말풍선에 이모지 그리기
        customer.emoji.GetComponent<Image>().sprite = GetEmojiSprite(emoji);
        customer.timer.GetComponent<Image>().sprite = GetEmojiSprite(emoji);
    }

    Sprite GetEmojiSprite(Enums.Emoji emoji) {
        switch (emoji) {
            case Enums.Emoji.orderwaiting:
                return DataContainer.instance.orderWaiting;
            case Enums.Emoji.menuwaiting:
                //주문한 메뉴 머리에 띄우기
                switch (customer.menu) {
                    case Enums.Menu.cheesecake:
                        return DataContainer.instance.cheesecake;
                    case Enums.Menu.chocolatecake:
                        return DataContainer.instance.chocolatecake;
                    case Enums.Menu.cookiecheesecake:
                        return DataContainer.instance.cookiecheesecake;
                    case Enums.Menu.croissant:
                        return DataContainer.instance.croissant;
                    case Enums.Menu.pancake:
                        return DataContainer.instance.pancake;
                    case Enums.Menu.chocolatepancake:
                        return DataContainer.instance.chocolatepancake;
                    case Enums.Menu.tirimasu:
                        return DataContainer.instance.tirimasu;
                    default:
                        Debug.LogError("일치하는 스프라이트 없음");
                        return null;
                }
            case Enums.Emoji.enjoying:
                return DataContainer.instance.enjoying;
            case Enums.Emoji.angryleaving:
                return DataContainer.instance.angryLeaving;
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
