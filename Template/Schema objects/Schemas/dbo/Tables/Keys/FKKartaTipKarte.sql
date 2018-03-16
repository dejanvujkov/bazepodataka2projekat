ALTER TABLE Karta
    ADD CONSTRAINT karta_tip_karte_fk FOREIGN KEY ( tip_karte_idtipa )
        REFERENCES tip_karte ( idtipa )