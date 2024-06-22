private static ulong GetHash(string s)
		{
			ulong num = 14695981039346656037UL;
			try
			{
				foreach (byte b in Encoding.UTF8.GetBytes(s))
				{
					num ^= (ulong)b;
					num *= 1099511628211UL;
				}
			}
			catch
			{
			}
			return num ^ 6605813339339102567UL;
		}