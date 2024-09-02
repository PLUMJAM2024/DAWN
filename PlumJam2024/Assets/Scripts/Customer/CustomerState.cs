using Unity.VisualScripting;
using UnityEngine;

public abstract class CustomerState : MonoBehaviour
{
    protected CustomerStateMachine stateMachine;
    protected Customer customer;
    public virtual void Enter(CustomerStateMachine stateMachine) {
        Debug.Log($"State : {this.GetType().Name}");
        this.stateMachine = stateMachine;
        customer = GetComponent<Customer>();
    }

    public abstract void _Update();

    public abstract void Exit();

    public virtual void ShowEmoji(Enums.Emoji emoji) {
        //말풍선 활성화
        customer.speechBubble.SetActive(true);
        //말풍선에 이모지 그리기
        customer.emoji.GetComponent<SpriteRenderer>().sprite = GetEmojiSprite(emoji);
    }

    Sprite GetEmojiSprite(Enums.Emoji emoji) {
        switch (emoji) {
            case Enums.Emoji.orderwaiting:
                return DataContainer.instance.orderWaiting;
            case Enums.Emoji.menuwaiting:
                //주문한 메뉴 머리에 띄우기
                switch (customer.menu) {
                    case Enums.Menu.cake:
                        return DataContainer.instance.cake;
                    case Enums.Menu.bread:
                        return DataContainer.instance.bread;
                    case Enums.Menu.coffee:
                        return DataContainer.instance.coffee;
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
        customer.speechBubble.SetActive(false);
    }
}
