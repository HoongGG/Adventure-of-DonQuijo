using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    private Timer dashMaintainTimer; // dash ���¿��� �¿�� ��ȯ�� ª�� �ð� ���� idle�� �Ǹ鼭 dash ���°� Ǯ���� ������ ����

    public PlayerIdleState(Player player, string animBoolName) : base(player, animBoolName)
    {
        dashMaintainTimer = new Timer(playerData.dashMaintainTime);
        dashMaintainTimer.timerAction += () => { player.moveState.StopDash(); };
    }

    public override void Enter()
    {
        base.Enter();

        player.movement.SetVelocityZero();
        dashMaintainTimer.StartSingleUseTimer();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!onStateExit)
        {
            dashMaintainTimer.Tick();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!onStateExit)
        {
            if (inputX != 0 || inputY != 0)
            {
                stateMachine.ChangeState(player.moveState);
            }
        }
    }
}
