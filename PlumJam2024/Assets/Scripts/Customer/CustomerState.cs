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
        //��ǳ�� Ȱ��ȭ
        customer.canvas.SetActive(true);
        //��ǳ���� �̸��� �׸���
        customer.emoji.GetComponent<Image>().sprite = GetEmojiSprite(emoji);
        customer.timer.GetComponent<Image>().sprite = GetEmojiSprite(emoji);
    }

    Sprite GetEmojiSprite(EmojiSO emoji) {
        switch (emoji.name)
        {
            case "orderwaiting":
                return DataManager.instance.emojis["orderwaiting"].GetSprite();
            case "menuwaiting":
                //�ֹ��� �޴� �Ӹ��� ����
                return customer.menu.GetSprite();
            case "enjoying":
                return DataManager.instance.emojis["enjoying"].GetSprite();
            case "angryleaving":
                return DataManager.instance.emojis["angryleaving"].GetSprite();
            default:
                Debug.LogError("��ġ�ϴ� ��������Ʈ ����");
                return null;
        }
        Debug.LogError("��ġ�ϴ� ��������Ʈ ����");
        return null;
    }

    public virtual void HideEmoji() {
        //��ǳ�� ��Ȱ��ȭ
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
