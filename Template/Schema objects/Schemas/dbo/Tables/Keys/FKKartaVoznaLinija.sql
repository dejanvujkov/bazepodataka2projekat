ALTER TABLE Karta
    ADD CONSTRAINT karta_vozna_linija_fk FOREIGN KEY ( vozna_linija_idlinije )
        REFERENCES vozna_linija ( idlinije )