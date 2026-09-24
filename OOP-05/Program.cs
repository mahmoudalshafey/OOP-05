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

            #region Ques 2
            /* 
             a - A copy where a new outer object is created, but any reference-type members inside it still point to the same inner objects as the original. MemberwiseClone() does this: value-type fields get duplicated, but reference-type fields just copy the reference.
             b - A copy where the new object gets its own independent copies of every reference-type member too — nothing is shared with the original at any level
             c - They stay shared. Both the original and the copy point to the exact same instance. Changing that member through one variable is visible through the other.
             d - They get cloned into new, independent instances. Changing the copy's version has no effect on the original's version.
             e - Undo/history systems, or any case where you need to modify a copy of an object for a "what-if" scenario without risking corrupting the live/original data — a Shallow Copy would silently mutate the original through the shared reference, which is a dangerous, hard-to-debug bug.
            */
            #endregion


        }
    }
}
