package org.example.mypackage;

import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.Select;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

public class PastebinPage2 {
    private WebDriver driver;

    public PastebinPage2(WebDriver driver) {
        this.driver = driver;
    }

    public void createNewPaste(String code, String syntaxHighlighting, String expiration, String title) throws InterruptedException {
        WebElement textArea = driver.findElement(By.id("postform-text"));
        textArea.sendKeys(code);

        // Открываем выпадающий список для синтаксиса подсветки
        WebElement syntaxHighlightingDropdown = driver.findElement(By.id("select2-postform-format-container"));
        syntaxHighlightingDropdown.click();

        // Находим элемент с нужным синтаксисом и кликаем на него
        WebElement syntaxHighlightingOption = driver.findElement(By.xpath("//li[text()='" + syntaxHighlighting + "']"));
        syntaxHighlightingOption.click();
        //////////////////////////////////

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
        //Thread.sleep(20000);


        WebElement createButton = driver.findElement(By.id("w0"));
        createButton.click();
    }
}
