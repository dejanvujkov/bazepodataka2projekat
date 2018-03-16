ALTER TABLE prodaje
    ADD CONSTRAINT prodaje_karta_fk FOREIGN KEY ( karta_idkarte )
        REFERENCES karta ( idkarte )