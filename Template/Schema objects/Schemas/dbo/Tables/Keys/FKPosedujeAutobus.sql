ALTER TABLE Poseduje
    ADD CONSTRAINT poseduje_autobus_fk FOREIGN KEY ( autobus_brtablica )
        REFERENCES autobus ( brtablica )