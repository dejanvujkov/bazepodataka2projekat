ALTER TABLE Poseduje
    ADD CONSTRAINT poseduje_autobuska_stanica_fk FOREIGN KEY ( autobuska_stanica_idstanice )
        REFERENCES autobuska_stanica ( idstanice )