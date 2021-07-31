using System.Windows.Forms;

namespace CSharpSimpleInjector
{
    public class Cat : IAnimal
    {
        public void MakeSound()
        {
            MessageBox.Show("Meow");
        }
    }
}
