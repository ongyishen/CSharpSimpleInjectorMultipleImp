using System.Windows.Forms;

namespace CSharpSimpleInjector
{
    public class Dog : IAnimal
    {
        public void MakeSound()
        {
            MessageBox.Show("Bark");
        }
    }
}
