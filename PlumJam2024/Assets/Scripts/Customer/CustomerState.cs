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
        //��ǳ�� Ȱ��ȭ
        customer.speechBubble.SetActive(true);
        //��ǳ���� �̸��� �׸���
        customer.emoji.GetComponent<SpriteRenderer>().sprite = GetEmojiSprite(emoji);
    }

    Sprite GetEmojiSprite(Enums.Emoji emoji) {
        switch (emoji) {
            case Enums.Emoji.orderwaiting:
                return DataContainer.instance.orderWaiting;
            case Enums.Emoji.menuwaiting:
                //�ֹ��� �޴� �Ӹ��� ����
                switch (customer.menu) {
                    case Enums.Menu.cake:
                        return DataContainer.instance.cake;
                    case Enums.Menu.bread:
                        return DataContainer.instance.bread;
                    case Enums.Menu.coffee:
                        return DataContainer.instance.coffee;
                    default:
                        Debug.LogError("��ġ�ϴ� ��������Ʈ ����");
                        return null;
                }
            case Enums.Emoji.enjoying:
                return DataContainer.instance.enjoying;
            case Enums.Emoji.angryleaving:
                return DataContainer.instance.angryLeaving;
            default:
                Debug.LogError("��ġ�ϴ� ��������Ʈ ����");
                return null;
        }
        Debug.LogError("��ġ�ϴ� ��������Ʈ ����");
        return null;
    }

    public virtual void HideEmoji() {
        //��ǳ�� ��Ȱ��ȭ
        customer.speechBubble.SetActive(false);
    }
}
