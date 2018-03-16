ALTER TABLE prodaje
    ADD CONSTRAINT prodaje_prodavac_fk FOREIGN KEY ( prodavac_jmbg )
        REFERENCES prodavac ( jmbg )