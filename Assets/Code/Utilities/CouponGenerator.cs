using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class CouponGenerator : MonoBehaviour
{
	[SerializeField] private int couponLength;
	[SerializeField] private int codesPerLanguage;
	[SerializeField] private int codesForAll;

	private List<int> possibleChars;
	private List<Coupon> coupons;
	private List<string> codes;

	List<Coupon> Generate() {
		// 0-9 = 48-57
		// A-Z = 65-90
		// a-z = 97-122
		possibleChars = new List<int>();
		codes = new List<string>();
		int i;
		for (i = 48; i <= 57; i++) possibleChars.Add(i);
		for (i = 65; i <= 90; i++) possibleChars.Add(i);
		for (i = 97; i <= 122; i++) possibleChars.Add(i);
		for (i = 0; i < 1000; i++) {
			string code = GetCode();
			codes.Add(code);
		}
		for (i = 0; i < Languages.All.Length; i++) {
			Language language = Languages.All[i]; 
			CreateCouponsFor(language, i, false);
		}
		CreateCouponsFor(Language.English, i, true);
		return coupons;
	}

	string GetCode() {
		var sb = new StringBuilder();
		int randChar;
		for (int i = 0; i < couponLength; i++) {
			randChar = UnityEngine.Random.Range(0, possibleChars.Count);
			sb.Append((char)possibleChars[randChar]);
		}
		return sb.ToString();
	}

	void CreateCouponsFor(Language language, int startRange, bool isForAll) {
		coupons = new List<Coupon>();
		int total = isForAll ? codesForAll : codesPerLanguage;
		for (int i = startRange; i < total; i++) {
			var coupon = new Coupon();
			coupon.Code = codes[i];
			coupon.IsUsed = false;
			string langName = isForAll ? "All" : language.ToString();
			coupon.Action = "unlock-" + langName;
			coupons.Add(coupon);
		}
	}

	public class Coupon {
		public string Code;
		public bool IsUsed;
		public string Action;
	}

}
