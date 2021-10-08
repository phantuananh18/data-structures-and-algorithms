static void SortString(string s)
        {
            char temp;
            string str = s.ToLower();
            char[] charString = str.ToCharArray();
            for (int i = 1; i < charString.Length; i++)
            {
                for (int j = 0; j < charString.Length - 1; j++)
                {
                    if (charString[j] > charString[j + 1])
                    {
                        temp = charString[j];
                        charString[j] = charString[j + 1];
                        charString[j + 1] = temp;
                    }
                }
            }
        }