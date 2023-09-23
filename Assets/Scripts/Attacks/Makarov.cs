public class Makarov : RangeAttack
{
    public override void Attack()
    {
        if (_time <= 0)
        {
            Shoot();
            _time = _reloadTime;
        }
    }
}
