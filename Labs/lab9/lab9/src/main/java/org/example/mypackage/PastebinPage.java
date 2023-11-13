package org.example.mypackage;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.Select;
import org.openqa.selenium.support.ui.WebDriverWait;

public class PastebinPage {
    private WebDriver driver;

    public PastebinPage(WebDriver driver) {
        this.driver = driver;
    }

    public void openPage() {
        driver.get("https://pastebin.com");

    }

    public void createNewPaste(String code, String expiration, String title) {

        WebElement textArea = driver.findElement(By.id("postform-text"));
        textArea.sendKeys(code);


        By expirationDropdownSelector = By.id("select2-postform-expiration-container");
        By dropdownItemSelector = By.xpath("//ul[@id='select2-postform-expiration-results']/li[text()='" + expiration + "']");

// Нажать на контейнер выпадающего списка
        WebElement expirationDropdownContainer = driver.findElement(expirationDropdownSelector);
        expirationDropdownContainer.click();

// Выбрать желаемое значение
        WebElement expirationDropdownItem = driver.findElement(dropdownItemSelector);
        expirationDropdownItem.click();






        WebElement pasteName = driver.findElement(By.id("postform-name"));
        pasteName.sendKeys(title);
    }
}
