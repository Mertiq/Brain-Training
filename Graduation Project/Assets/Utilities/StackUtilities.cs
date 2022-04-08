using System.Collections;

namespace Utilities {
    public static class StackUtilities
    {

        public static bool AreStacksSame(Stack stack1, Stack stack2){
            if(stack1.Count != stack2.Count) {
                return false;
            }
            int[] stack1elements = new int[stack1.Count];
            stack1.CopyTo(stack1elements, 0);
            
            int[] stack2elements = new int[stack2.Count];
            stack2.CopyTo(stack2elements, 0);

            for(int i=0; i < stack1elements.Length; i++) {
                if(stack1elements[i] != stack2elements[i]){
                    return false;
                }
            }
            return true;
        }
    }
}