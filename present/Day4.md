<!-- .slide: data-auto-animate data-auto-animate-id="isolate" -->
# <font color="#ad5dc1">High Level</font>
<!-- .element: style="font-size:8rem" -->

# <font color="#8fb730">Testing</font>
<!-- .element: style="font-size:8rem" -->

---

### 🤔 <font color="#8fb730">Unit Testing</font> อยู่ตรงไหน ?

[The Practical Test Pyramid](https://martinfowler.com/articles/practical-test-pyramid.html)
<!-- .element: style="font-size:1.6rem" -->

![img](../assets/testing-2.png)

---

## 🤨 Unit Testing มี<font color="#f92f60">ข้อเสีย</font>ไหม?

---

### 🤨 เทสนี้คือฟีเจอร์อะไร ?

```csharp
[Theory]
[InlineData(3, 5, 8)]
[InlineData(2, 8, 10)]
public void Add_TwoPositiveValues_MustBeWorkingCorrectly(
	int input1, int input2, int expected)
{
	// ...
}

[Theory]
[InlineData(-7, -5, -12)]
[InlineData(-9, -20, -29)]
public void Add_TwoNegativeValues_MustBeWorkingCorrectly(
	int input1, int input2, int expected)
{
	// ...
}
```
<!-- .element: style="width:55%;" -->

`👷‍♂️ถามคนงาน`


---

## Unit Testing
<!-- .element: style="color:#8fb730;" -->

![img](../assets/perspective-1.png) <!-- .element: style="margin-top:0px;margin-bottom:0px" -->

`🤨 จะไปที่ไหน ?`

---

# 👩‍💼→🧑‍💻

<font color="#ad5dc1">Business</font> → <font color="#f92f60">Requirements</font> → <font color="#3f8dd5">Developers</font> → <font color="#8fb730">**TDD**</font>
<!-- .element: style="font-size:2rem" -->

`เดฟเข้าใจความต้องการถูกไหม?` `จะเริ่มเขียนเทสจากเรื่องไหนก่อน?` `ระดับการเทสละเอียดเกินไป` `ในกระบวนการไม่มีทีมเทส`
<!-- .element: class="small" -->

---

<!-- .slide: data-auto-animate data-auto-animate-id="tdd" -->
## BDD
<!-- .element: style="color:#ad5dc1;" -->

# <font color="#8fb730">Behavior</font> <font color="#f92f60">Driven</font> <font color="orange">Development</font>

---

<!-- .slide: data-auto-animate data-auto-animate-id="tdd" -->
## BDD
<!-- .element: style="color:#ad5dc1;" -->

> “BDD is <font color="orange">**an agile software development process**</font> that encourages collaboration among developers, quality assurance experts, and customer representatives in a software project. <font color="#8fb730">It encourages teams to use conversation and concrete examples to formalize a shared understanding of how the application should behave.</font> It emerged from test-driven development (TDD).” ━ Wikipedia
<!-- .element: style="width:100%;font-size:2.1rem" -->

`แชร์ความเข้าใจสิ่งที่ระบบควรจะต้องเป็น โดยใช้ตัวอย่างที่ชัดเจน`

---

<!-- .slide: data-auto-animate data-auto-animate-id="tdd" -->
## BDD
<!-- .element: style="color:#ad5dc1;" -->

![img](../assets/perspective-2.png) <!-- .element: style="margin-top:0px;margin-bottom:0px" -->

`🎯 เข้าใจภาพรวมของระบบ`

---

<!-- .slide: data-auto-animate data-auto-animate-id="tdd" -->
## BDD
<!-- .element: style="color:#ad5dc1;" -->

![img](../assets/specflow.png)

> แปลง Business requirements  ให้กลายเป็น Scenarios ที่ทุกคนสามารถเข้าใจได้ แล้วนำ Scenarios เหล่านั้นไปสร้างเป็น Living document
<!-- .element: style="width:100%;font-size:2.1rem" -->

---

# Specflow <!-- .element: style="color:#ad5dc1;" -->

> “Specflow is a <font color="8fb730">test automation solution for .NET built upon the BDD paradigm</font>. Use SpecFlow to define, manage and automatically execute human-readable acceptance tests in .NET projects (Full Framework and .NET Core). <font color="orange">SpecFlow tests are written using Gherkin</font>, which allows you to write test cases using natural languages.” ━ [Specflow](https://specflow.org)
<!-- .element: style="width:100%;font-size:1.9rem" -->

---

## Gherkin Syntax
<!-- .element: style="color:#8fb730;" -->

Given ━ When ━ Then

```gherkin
Feature: Calculator
	Calculator for adding two numbers
 
Scenario: Add two integer numbers with the calculator
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario: Add two decimal numbers with the calculator
	Given I have entered 7.5 into the calculator
	And I have entered 2.8 into the calculator
	When I press add
	Then the result should be 10.3 on the screen
```
<!-- .element: style="width:50%;" -->

`🥰 ภาษาที่คนเข้าใจ`

---

## 🍿 Demo `D08`

# Specflow
<!-- .element: style="color:#ad5dc1;font-size:12rem" -->

---

## 🤨 BDD <font color="#f92f60">ต่างจาก</font> TDD ยังไง ?

---

### 🏨 Specification by example

```gherkin
Feature: ค่าบริการห้องพักโรงแรม

การคำนวณค่าห้องพักโรงแรมจะประกอบไปด้วย ค่าห้องพักต่อคืน และ ค่าใช้จ่ายเพิ่มเติมต่างๆ
เช่น ผู้ใช้บริการขอเข้าห้องก่อนเวลาที่กำหนด ผู้ใช้บริการขอคืนห้องล่าช้า ฯลฯ ซึ่งค่าใช้จ่าย
ทั้งหมดมีรายละเอียดในการคำนวณตามด้านล่างนี้

	1. ราคาห้องพักจะขึ้นอยู่กับระดับห้องพักที่เลือกดังนี้
		| Grade    | Cost/Day  |
		| Standard | 1000      |
		| Superior | 2500      |
		| Deluxe   | 7000      |
	2. ถ้าผู้ใช้บริการเข้าพักหลังเวลา 12:00 และ 
	   คืนห้องก่อนเวลา 12:00 จะไม่มีค่าใช้จ่ายเพิ่มเติม
	3. กรณีผู้ใช้บริการเข้าพักหรือคืนห้องนอกเวลา จะมีค่าใช้จ่ายเพิ่มเติมดังนี้
		| Case               		 | Penalty |
		| Early check-in before  6:00 | 100%    |
		| Early check-in after   6:00 | 50%     |
		| Late check-out before 12:00 | 50%     |
		| Late check-out after  18:00 | 100%    |
 
Scenario: ผู้ใช้บริการที่เข้าพักและคืนห้องในช่วงเวลาปรกติ จะต้องไม่มีค่าใช้จ่ายเพิ่มเติม
	Given ผู้ใช้เลือกห้องพักระดับ Standard
	And เริ่มเข้าพักเมื่อ 1/2/2022 เวลา 15:13
	And คืนห้องพักเมื่อ 4/2/2022 เวลา 11:45
	When ผู้ใช้บริการขอชำระเงินค่าห้องพัก
	Then ระบบแจ้งค่าใช้จ่ายรวมทั้งหมด 3000 บาท
	And ระบบทำการบันทึกรายละเอียดค่าใช้จ่ายเป็นดังนี้
		| No | Range 						  | Cost |
		| 1  | 1/2/2022 15:13 - 2/2/2022 12:00 | 1000 |
		| 2  | 2/2/2022 12:00 - 3/2/2022 12:00 | 1000 |
		| 3  | 3/2/2022 12:00 - 4/2/2022 11:45 | 1000 |

Scenario: ผู้ใช้บริการเข้าพักและคืนห้องนอกเวลา จะมีค่าใช้จ่ายเพิ่มเติม
	Given ผู้ใช้เลือกห้องพักระดับ Standard
	And เริ่มเข้าพักเมื่อ 5/2/2022 เวลา 6:31
	And คืนห้องพักเมื่อ 5/2/2022 เวลา 18:20
	When ผู้ใช้บริการขอชำระเงินค่าห้องพัก
	Then ระบบแจ้งค่าใช้จ่ายรวมทั้งหมด 1500 บาท
	And ระบบทำการบันทึกรายละเอียดค่าใช้จ่ายเป็นดังนี้
		| No | Range 						  | Cost |
		| 1  | 5/2/2022 06:31 - 5/2/2022 12:00 | 500  |
		| 2  | 5/2/2022 12:00 - 5/2/2022 18:20 | 1000 |
```
<!-- .element: style="width:65%;" -->

---

## 🎮 Challenge `12`
# โปรแกรมตัดเกรด
<!-- .element: style="color:#f92f60;" -->

|ช่วงคะแนน|85+|70+|60+|50+|อื่นๆ|
|--|--|--|--|--|--|
เกรดที่ได้|A|B|C|D|F|
<!-- .element: style="font-size:2rem" -->

`แก้เกณฑ์การให้คะแนนได้` ━ `เลือกแสดงผลลัพท์ให้ออกทางหน้าจอ หรือ จะพิมพ์ลงกระดาษได้`
`Specflow`
<!-- .element: style="color:#747474;font-size:2rem" -->

---

### 🤔 BDD อยู่ตรงไหน ?

[The Practical Test Pyramid](https://martinfowler.com/articles/practical-test-pyramid.html)
<!-- .element: style="font-size:1.6rem" -->

![img](../assets/testing-2.png)

---

# 🤨 เมื่อไหร่ใช้ตัวไหน ? <!-- .element: style="color:orange;font-size:1.5rem" -->
## <font color="#8fb730">TDD</font> ⚔️ <font color="#ad5dc1">BDD</font> 

|TDD <!-- .element: style="color:#8fb730;" -->|BDD <!-- .element: style="color:orange;" -->|
|--|--|
|เน้นเฉพาะจุด|เน้นภาพรวม|
|เดฟเขียน|ทุกคนช่วยกันเขียนได้|
|เฉพาะเดฟอ่าน|ทุกคนอ่านและช่วยกันตรวจได้|
|White Box Testing|Black Box Testing|

---

## 😉 <font color="#8fb730">TDD</font> + <font color="#ad5dc1">BDD</font> 

![img](../assets/bddNtdd.png)

`ขึ้นอยู่กับสถานะการณ์`

เอา BDD (Feature) คลุม TDD (Specific task)
<!-- .element: style="font-size:2rem" -->

===

# <font color="orange">End to End</font>
<!-- .element: style="font-size:8rem" -->

# <font color="#f92f60">Testing</font>
<!-- .element: style="font-size:8rem" -->

---

### 🤔 <font color="orange">End to End Testing</font> อยู่ตรงไหน ?

[The Practical Test Pyramid](https://martinfowler.com/articles/practical-test-pyramid.html)
<!-- .element: style="font-size:1.6rem" -->

![img](../assets/testing-2.png)

---

## <font color="orange">End to End</font> (E2E)

![img](../assets/e2e-1.png)

`🕵️ เทสตั้งแต่ทางเข้ายันทางออก` `Behaviour` `(UX) User Experience`
<!-- .element: class="small" -->

---

## 🤔 E2E <font color="#f92f60">เทสกันยังไง</font>?

1. Manual Testing
1. Semi-automated Testing
1. Automated Testing

---

## Testing Strategies
<!-- .element: style="color:#f92f60;" -->

1. `🐒 Monkey Testing` ━ เทสทั้งระบบ โดยการสุ่ม inputs แบบต่างๆ เพื่อตรวจหาข้อผิดพลาดของระบบ [`Random Testing`](https://en.wikipedia.org/wiki/Random_testing) [`Fuzz Testing`](https://en.wikipedia.org/wiki/Fuzzing)
	* 🙈 Dumb monkey testing ━ ไม่รู้เลยว่าระบบที่กำลังจะเทสคืออะไร <!-- .element: style="font-size:1.5rem" -->
	* 🙉 Smart monkey testing ━ รู้อยู่แล้วว่าระบบที่จะเทสคืออะไร <!-- .element: style="font-size:1.5rem" -->
	* 🐵 Brilliant monkey testing ━ รู้เรื่องระบบและจุดต่างๆที่อาจเกิดข้อผิดพลาดด้วย <!-- .element: style="font-size:1.5rem" -->
1. `🦍 Gorilla Testing` ━ เทสเฉพาะจุดที่สนใจ โดยการสุ่ม input แบบต่างๆ และทดสอบจุดเดิมหลายๆรอบ เพื่อตรวจว่าระบบสามารถทำงานได้เป็นปรกติหรือไม่

<!-- .element: style="font-size:2rem" -->

---

# <font color="#f92f60">A</font>p<font color="#8fb730">p</font> <font color="#3f8dd5">T</font><font color="#ad5dc1">y</font><font color="#747474">p</font><font color="#9d0098">e</font><font color="orange">s</font>

|Web <!-- .element: style="color:#8fb730" -->|Mobile <!-- .element: style="color:orange" -->|Desktop <!-- .element: style="color:#ad5dc1" -->|
|--|--|--|
|`Static` `Dynamic` `SPA` `MPA` `Service` `...`|`Android` `iOS` `Windows Phone` `Native` `Xamarin` `Game` `...`|`macOS` `Windows` `Linux` `Console` `MAUI` `WPF` `XBox` `...`|

<!-- .element: class="small" -->

---

<!-- .slide: data-auto-animate data-auto-animate-id="tdd" -->
# Playwright
<!-- .element: style="color:#8fb730;font-size:10rem" -->

[Playwright](https://playwright.dev/dotnet) enables reliable end-to-end testing for modern web apps.

---

<!-- .slide: data-auto-animate data-auto-animate-id="tdd" -->
## 🍿 Demo `D09`

# Playwright
<!-- .element: style="color:#8fb730;font-size:12rem" -->

---

<!-- .slide: data-auto-animate data-auto-animate-id="tdd" -->
# Playwright
<!-- .element: style="color:#8fb730;font-size:10rem" -->

`Cross-browser` `Cross-platform` `Cross-language` `Test Mobile Web` `Tracing` `Events` `DOM` `Authentication` `Codegen`

---

## 🎮 Challenge `13`
# Logout !!
<!-- .element: style="color:#ad5dc1;font-size:12rem" -->

---

## 🤨 Manual Testing
# ยังจำเป็นอยู่ไหม ?
<!-- .element: style="color:#f92f60;" -->

---

## 😏 แอพใช้งานได้ไม่ใช่ทุกสิ่ง

![img](../assets/ui.png)

`Manual Testing` 💘 `Automation Testing`

===

# TDD Kata

> “<font color="orange">Kata is a Japanese word (型 or 形) meaning "form".</font> It refers to a detailed choreographed pattern of martial arts movements made to be practised alone. It can also be reviewed within groups and in unison when training. <font color="#8fb730">It is practised in Japanese martial arts as a way to memorize and perfect the movements being executed.</font>” ━ Wikipedia
<!-- .element: style="width:100%;font-size:2rem" -->

`ฝึกเรียนรู้กระบวนท่า`

---

<!-- .slide: data-auto-animate data-auto-animate-id="tdd" -->
## 🎮 Challenge `14`

# [String Calculator](https://kata-log.rocks/string-calculator-kata)

`TDD Kata`

---

<!-- .slide: data-auto-animate data-auto-animate-id="tdd" -->
## 🎮 Challenge `15`

# [Roman Numerals](https://www.codewars.com/kata/51b62bf6a9c58071c600001b)

`TDD Kata`

---

<!-- .slide: data-auto-animate data-auto-animate-id="tdd" -->
## 🎮 Challenge `16`

# [Banking Kata](https://kata-log.rocks/banking-kata)

`SOLID Principles` `Software Design`

---

<!-- .slide: data-auto-animate data-auto-animate-id="tdd" -->
## 🎮 Challenge `17`

# [Manhattan Distance](https://www.codewars.com/kata/52998bf8caa22d98b800003a)

`TDD Kata`

===

# 🎉 Summary
<!-- .element: style="color:#8fb730;" -->

1. <font color="#ad5dc1">BDD</font> → `Specflow`
	* Specification by Example
	* Feature( Unit Testing )
1. <font color="orange">E2E Testing</font> → `Playwright`
	* Manual Testing + Automation Testing
1. TDD Kata