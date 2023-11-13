package org.example.mypackage;

import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.Select;
import org.testng.Assert;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

public class PastebinTest2 {
    private WebDriver driver;

    @BeforeMethod
    public void setUp() {
        System.setProperty("webdriver.chrome.driver", "D:/chromedriver-win32/chromedriver.exe");
        driver = new ChromeDriver();
    }

    @Test
    public void testPastebinScenario() throws InterruptedException {

        driver.get("https://pastebin.com");

        // Создать New Paste
        PastebinPage2 pastebinPage = new PastebinPage2(driver);
        pastebinPage.createNewPaste("git config --global user.name  \"New Sheriff in Town\"\n" +
                "git reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\n" +
                "git push origin master --force", "Bash", "10 Minutes", "how to gain dominance among developers");

        // Проверить заголовок страницы
        //String pageTitle = driver.getTitle();
        //Assert.assertEquals(pageTitle, "how to gain dominance among developers - Pastebin.com");
        String expectedTitle = "how to gain dominance among developers";
        String actualTitle = driver.getTitle();
        Assert.assertEquals(actualTitle, expectedTitle, "Заголовок страницы не соответствует ожидаемому");



       /* // Проверить синтаксис подсветки
        WebElement codeArea = driver.findElement(By.xpath("//ol[@class='bash']"));
        String codeText = codeArea.getText();
        Assert.assertTrue(codeText.contains("git config --global user.name  \"New Sheriff in Town\""));

        // Проверить введенный код
        WebElement pasteContent = driver.findElement(By.xpath("//textarea[@class='textarea']"));
        String pasteText = pasteContent.getText();
        String expectedText = "git config --global user.name  \"New Sheriff in Town\"\n" +
                "git reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\n" +
                "git push origin master --force";
        Assert.assertEquals(pasteText, expectedText);*/
    }

    @AfterMethod
    public void tearDown() throws InterruptedException {
        if (driver != null) {
            Thread.sleep(20000);
            driver.quit();
        }
    }
}
