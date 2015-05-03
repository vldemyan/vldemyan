package selenium2;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.firefox.FirefoxDriver;
public class class1 {
 
    public static void main(String[] args) {
        WebDriver driver = new FirefoxDriver();
        String baseUrl = "http://localhost/guestbook/index.html";
        driver.get(baseUrl);
        String alertMessage = "";
        
        WebElement el1 = driver.findElement(By.id("your_name"));
        el1.sendKeys("my name");

        WebElement button1 = driver.findElement(By.id("button"));
        button1.click();

        alertMessage = driver.switchTo().alert().getText();
        System.out.println(alertMessage);
        if(alertMessage.equals("Fill in all feilds.")){
        	  System.out.println("Test1 passed");  
        } else {
        	System.out.println("Test1 failed"); 
        }
        driver.switchTo().alert().accept();
        
        
        WebElement el2 = driver.findElement(By.id("email"));
        el2.sendKeys("mymail.gmail.com");
        
        button1.click();

        alertMessage = driver.switchTo().alert().getText();
        System.out.println(alertMessage);
        if(alertMessage.equals("Fill in all feilds.")){
        	  System.out.println("Test2 passed");  
        } else {
        	System.out.println("Test2 failed"); 
        }
        driver.switchTo().alert().accept();
        
        
        WebElement el3  = driver.findElement(By.id("comment"));
        el3.sendKeys("my comment");
        
        button1.click();

        alertMessage = driver.switchTo().alert().getText();
        System.out.println(alertMessage);
        if(alertMessage.equals("E-mail address is wrong")){
        	  System.out.println("Test3 passed");  
        } else {
        	System.out.println("Test3 failed"); 
        }
        driver.switchTo().alert().accept();
        
        
        el2.clear();
        el2.sendKeys("mymail@gmail.com");
        button1.click();
        
        driver.close();
    }
}
