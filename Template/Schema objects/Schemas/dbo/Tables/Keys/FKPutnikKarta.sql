ALTER TABLE Putnik
    ADD CONSTRAINT putnik_karta_fk FOREIGN KEY ( karta_idkarte )
        REFERENCES karta ( idkarte )