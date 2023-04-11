using Godot;

public partial class PlayerGuns : Node2D
{
    // Reference to the node that contains all the available guns that player can choose from
    [Export]
    public Node2D AvailableGunsCollection;

    // Currently equipped gun
    private BaseGun _equippedGun = null;

    public override void _Ready()
    {
        GD.Print("ready");

        EquipNextGun();
    }


    // Shot from current equipped gun
    public BaseGun Shoot()
    {
        GD.Print("shoot");

        return _equippedGun.ShootProjectile();
    }

    // Stop shooting a gun
    public void Release()
    {
        GD.Print("release");

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

        _equippedGun = (BaseGun)AvailableGunsCollection.GetChild(nextIndex); // Assign first as equipped

        return _equippedGun;
    }

    private int CalculateGunIndex(int currentIndex)
    {
        var maxIndex = AvailableGunsCollection.GetChildCount();

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
