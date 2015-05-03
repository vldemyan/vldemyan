package selenium2;

import static org.junit.Assert.*;

import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.firefox.FirefoxDriver;
public class class1 {

	@Test
    public void test1() throws InterruptedException {
        WebDriver driver = new FirefoxDriver();
        String baseUrl = "http://localhost/guestbook/index.html";
        driver.get(baseUrl);
        String alertMessage = "";
        
        WebElement el1 = driver.findElement(By.id("your_name"));
        el1.sendKeys("my name");
        Thread.sleep(1000);
        
        WebElement button1 = driver.findElement(By.id("button"));
        button1.click();
        Thread.sleep(1000);

        alertMessage = driver.switchTo().alert().getText();
        assertEquals("Message should be 'Fill in all feilds.'", "Fill in all feilds.", alertMessage);
        driver.switchTo().alert().accept();
        
        WebElement el2 = driver.findElement(By.id("email"));
        el2.sendKeys("mymail.gmail.com");
        Thread.sleep(1000);
        
        button1.click();
        Thread.sleep(1000);

        alertMessage = driver.switchTo().alert().getText();
        assertEquals("Message should be 'Fill in all feilds.'", "Fill in all feilds.", alertMessage);
        driver.switchTo().alert().accept();
        
        WebElement el3  = driver.findElement(By.id("comment"));
        el3.sendKeys("my comment");
        Thread.sleep(1000);
        
        button1.click();
        Thread.sleep(1000);

        alertMessage = driver.switchTo().alert().getText();
        assertEquals("Message should be 'E-mail address is wrong'", "E-mail address is wrong", alertMessage);
        driver.switchTo().alert().accept();
                
        el2.clear();
        el2.sendKeys("mymail@gmail.com");
        Thread.sleep(1000);
        
        button1.click();
        Thread.sleep(1000);
        
        driver.close();
    }
}