namespace neetcode.P1845_SeatReservationManager;

public class SeatManager
{
    private bool[] seats;

    public SeatManager(int n)
    {
        seats = new bool[n];
    }

    public int Reserve()
    {
        for (int i = 0; i < seats.Length; i++)
        {
            if (!seats[i])
            {
                seats[i] = true;
                return i + 1;
            }
        }
        return -1;
    }

    public void Unreserve(int seatNumber)
    {
        seats[seatNumber - 1] = false;
    }
}
