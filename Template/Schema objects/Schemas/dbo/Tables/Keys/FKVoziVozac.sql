ALTER TABLE vozi
    ADD CONSTRAINT vozi_vozac_fk FOREIGN KEY ( vozac_jmbg )
        REFERENCES vozac ( jmbg )