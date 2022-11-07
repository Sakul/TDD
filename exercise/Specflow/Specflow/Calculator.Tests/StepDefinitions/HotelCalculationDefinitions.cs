using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests.StepDefinitions
{
    [Binding]
    public sealed class HotelCalculationDefinitions
    {
        [Given(@"ผู้ใช้เลือกห้องพักระดับ Standard")]
        public void GivenผใชเลอกหองพกระดบStandard()
        {
            throw new PendingStepException();
        }

        [Given(@"เริ่มเข้าพักเมื่อ (.*)/(.*) เวลา (.*)")]
        public void Givenเรมเขาพกเมอเวลา(Decimal p0, int p1, Decimal p2)
        {
            throw new PendingStepException();
        }

        [Given(@"คืนห้องพักเมื่อ (.*)/(.*) เวลา (.*)")]
        public void Givenคนหองพกเมอเวลา(Decimal p0, int p1, Decimal p2)
        {
            throw new PendingStepException();
        }

        [When(@"ผู้ใช้บริการขอชำระเงินค่าห้องพัก")]
        public void Whenผใชบรการขอชำระเงนคาหองพก()
        {
            throw new PendingStepException();
        }

        [Then(@"ระบบแจ้งค่าใช้จ่ายรวมทั้งหมด (.*) บาท")]
        public void Thenระบบแจงคาใชจายรวมทงหมดบาท(int p0)
        {
            throw new PendingStepException();
        }

        [Then(@"ระบบทำการบันทึกรายละเอียดค่าใช้จ่ายเป็นดังนี้")]
        public void Thenระบบทำการบนทกรายละเอยดคาใชจายเปนดงน(Table table)
        {
            throw new PendingStepException();
        }
    }
}
