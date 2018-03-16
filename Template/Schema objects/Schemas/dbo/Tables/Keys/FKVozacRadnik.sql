ALTER TABLE Vozac
    ADD CONSTRAINT vozac_radnik_fk FOREIGN KEY ( jmbg )
        REFERENCES radnik ( jmbg )