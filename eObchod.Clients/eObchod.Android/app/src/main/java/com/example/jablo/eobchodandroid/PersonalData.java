package com.example.jablo.eobchodandroid;

import java.util.Date;

/**
 * Created by jablo on 11.05.2016.
 */
public class PersonalData {
    private String pesel;
    private String firstName;
    private String lastName;
    private String gender;
    private String birthDate;
    private int age;
    private String mainBookNumber;
    private String wardBookNumber;

    public String getPesel() {
        return pesel;
    }

    public void setPesel(String pesel) {
        this.pesel = pesel;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getGender() {
        return gender;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }

    public String getBirthDate() {
        return birthDate;
    }

    public void setBirthDate(String birthDate) {
        this.birthDate = birthDate;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public String getMainBookNumber() {
        return mainBookNumber;
    }

    public void setMainBookNumber(String mainBookNumber) {
        this.mainBookNumber = mainBookNumber;
    }

    public String getWardBookNumber() {
        return wardBookNumber;
    }

    public void setWardBookNumber(String wardBookNumber) {
        this.wardBookNumber = wardBookNumber;
    }
}
