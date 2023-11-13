package org.example.mypackage;

import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;
import org.openqa.selenium.WebDriver;

public class PastebinTest {
    private WebDriver driver;

    @BeforeMethod
    public void setUp() {
        System.setProperty("webdriver.chrome.driver", "D:/chromedriver-win32/chromedriver.exe");
        driver = new ChromeDriver();
    }

    @Test
    public void testPastebinScenario() {
        PastebinPage pastebinPage = new PastebinPage(driver);
        pastebinPage.openPage();

        pastebinPage.createNewPaste("Hello from WebDriver", "10 Minutes", "helloweb");
        // Добавьте ожидание или другие проверки по необходимости
    }

    @AfterMethod
    public void tearDown() throws InterruptedException {
        if (driver != null) {
            Thread.sleep(5000);
            driver.quit();
        }
    }
}
