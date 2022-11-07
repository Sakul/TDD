namespace LoginWithBackoff.App.Tests
{
    public class AuthenticatorTests
    {
        [Fact]
        public void Login_WithAValidUsernameAndPassword_ThenGotAToken()
        {
            var now = DateTime.Now;
            var sut = new Authenticator();
            var result = sut.Login("Admin1", "P@ssw0rd", now);

            Assert.True(false == string.IsNullOrWhiteSpace(result.Token));
            Assert.Equal(1, result.AttemptCount);
            Assert.Equal(now, result.CurrentServerTime);
            Assert.Null(result.UnlockTime);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public void Login_WithAnInvalidPassword_ThenGotAnError()
        {
            var now = DateTime.Now;
            var sut = new Authenticator();
            var result = sut.Login("Admin1", "0123456789", now);

            Assert.True(string.IsNullOrWhiteSpace(result.Token));
            Assert.Equal(1, result.AttemptCount);
            Assert.Equal(now, result.CurrentServerTime);
            Assert.Equal(now, result.UnlockTime);
            Assert.Equal("InvalidUsernameOrPassword", result.ErrorMessage);
        }

        // Normal cases
        // TODO: ใส่รหัสผ่านผิด ต้องไม่สามารถเข้าใช้งานได้
        // TODO: ใส่รหัสผ่านผิดครบ 3 ครั้ง จะถูกลงโทษให้รอ 30 วินาที

        // Alternative cases
        // TODO: ชื่อผู้ใช้งานสามารถสามารถใช้ตัวพิมพ์เล็กตัวพิมพ์ใหญ่แทนกันได้
        // TODO: ระบบต้องแจ้งเตือนข้อผิดพลาดกรณีได้รับชื่อผู้ใช้งานเป็นค่าว่าง และ ต้องทำการลงโทษผู้ใช้ใดๆ

        // Exceptional cases
        // TODO: ใส่ข้อมูลถูกต้องแต่ไม่ได้รับ Token และไม่มีข้อมูลการถูกลงโทษหรือข้อผิดพลาดใดๆ ระบบต้องส่งกลับมาเป็น InvalidOperationException
    }
}