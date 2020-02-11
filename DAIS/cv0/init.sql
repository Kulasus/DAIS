INSERT INTO student VALUES ('pla457','Jan','Plavácek');
INSERT INTO student VALUES ('sob458','Yveta','Sobotová');
INSERT INTO student VALUES ('kon355','Lukás','Kondiolka');

INSERT INTO kurz VALUES ('456-dais-01', 'Databázové a informacní systémy');
INSERT INTO kurz VALUES ('456-tzd-01', 'Teorie zpracování dat');
INSERT INTO kurz VALUES ('450-apps-01', 'Architektury pocítacu a paralelních systému');
INSERT INTO kurz VALUES ('457-pj-02', 'Programování 2');
INSERT INTO kurz VALUES ('458-pj-01', 'Programování 1');

INSERT INTO ucitel VALUES ('bay01', 'Josef', 'Bayer');
INSERT INTO ucitel VALUES ('cod02', 'Stanislav', 'Codd');

INSERT INTO studijniplan(kod,login,rok) VALUES ('456-dais-01','pla457','2009');
INSERT INTO studijniplan(kod,login,rok) VALUES ('456-tzd-01','pla457','2009');
INSERT INTO studijniplan(kod,login,rok) VALUES ('450-apps-01','pla457','2009');
INSERT INTO studijniplan(kod,login,rok) VALUES ('456-tzd-01','sob458','2009');
INSERT INTO studijniplan(kod,login,rok) VALUES ('456-dais-01','sob458','2009');
INSERT INTO studijniplan(kod,login,rok) VALUES ('458-pj-01','sob458','2009');
INSERT INTO studijniplan(kod,login,rok) VALUES ('458-pj-01','kon355','2009');
INSERT INTO studijniplan(kod,login,rok) VALUES ('457-pj-02','kon355','2009');
INSERT INTO studijniplan(kod,login,rok) VALUES ('456-dais-01','kon355','2009');

INSERT INTO garant(kod,login,rok) VALUES ('456-dais-01','bay01','2009');
INSERT INTO garant(kod,login,rok) VALUES ('456-tzd-01','bay01','2009');
INSERT INTO garant(kod,login,rok) VALUES ('450-apps-01','cod02','2009');
INSERT INTO garant(kod,login,rok) VALUES ('458-pj-01','cod02','2009');

SELECT * FROM kurz;