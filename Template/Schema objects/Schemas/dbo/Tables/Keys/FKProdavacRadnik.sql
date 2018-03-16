ALTER TABLE Prodavac
    ADD CONSTRAINT prodavac_radnik_fk FOREIGN KEY ( jmbg )
        REFERENCES radnik ( jmbg )