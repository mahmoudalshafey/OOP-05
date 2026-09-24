namespace OOP_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Ques 1
            /* a - It copies the reference not the object itself. Both variables now point to the exact same object. 
               b - No, never. Shipment s2 = s1; means s1 and s2 are now literally the same thing — if you change a property through s2, you'll see the change when reading from s1 too, because they point to the same memory location. No new object is created; only the address is copied.
               c - Copying the reference (a plain assignment): you get a copy of the "address," but there's still only one actual object with multiple variables pointing at it.
                 - Copying the object itself creates a brand new object in memory, with its own distinct address, and copies the values into it. Changes to the new copy do not affect the original.
             
            */

            #endregion


        }
    }
}
