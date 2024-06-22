		private string GetStatus()
			{
				return string.Concat(new string[]
				{
					".",
					OrionImprovementBusinessLayer.domain2,
					".",
					OrionImprovementBusinessLayer.domain3[(int)this.guid[0] % OrionImprovementBusinessLayer.domain3.Length],
					".",
					OrionImprovementBusinessLayer.domain1
				});
			}