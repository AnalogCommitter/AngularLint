using System;

public class TipRequest
{
    public int[] Numbers { get; set; }

    public bool Joker { get; set; }
}

public class TipResponse
{
    public DateTime ReceiptTimestamp { get; set; }

    public int ReceiptNumber { get; set; }
}

public class TipResult
{
    public int CorrectNumbers { get; set; }

    public bool Zusatzzahl { get; set; }
}