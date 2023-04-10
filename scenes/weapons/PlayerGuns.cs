using Godot;
using System;

public partial class PlayerGuns : Node2D
{
    private BaseGun _equippedGun = null;

    private Node _availableGuns;

    public override void _Ready()
    {
        GD.Print("ready");

        _availableGuns = GetNode<Node>($"%{nameof(_availableGuns)}");

        EquipNextGun();
    }


    // Shot from current equipped gun
    public BaseGun Shoot()
    {
        return _equippedGun.ShootProjectile();
    }

    // Stop shooting a gun
    public void Release()
    {
        _equippedGun.Release();
    }

    // Choose 
    public BaseGun EquipNextGun()
    {
        return EquipGun(1);
    }

    public BaseGun EquipPreviousGun()
    {
        return EquipGun(-1);
    }

    public BaseGun GetEquippedGun()
    {
        GD.Print("get");

        return _equippedGun;
    }

    private BaseGun EquipGun(int direction)
    {
        var nextIndex = 0;

        if (_equippedGun != null)
        {
            nextIndex = CalculateGunIndex(_equippedGun.GetIndex() + direction);
        }

        _equippedGun = (BaseGun)_availableGuns.GetChild(nextIndex); // Assign first as equipped

        return _equippedGun;
    }

    private int CalculateGunIndex(int currentIndex)
    {
        var maxIndex = _availableGuns.GetChildCount();

        if (currentIndex < 0)
        {
            GD.Print($"{currentIndex} -> {maxIndex - 1}");

            return maxIndex - 1;
        }
        else
        {
            var indexMod = (currentIndex) % maxIndex;

            GD.Print($"{currentIndex} -> {indexMod}/{maxIndex}");

            return indexMod;
        }
    }
}
