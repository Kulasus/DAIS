INSERT INTO student VALUES ('pla457','Jan','Plav�cek');
INSERT INTO student VALUES ('sob458','Yveta','Sobotov�');
INSERT INTO student VALUES ('kon355','Luk�s','Kondiolka');

INSERT INTO kurz VALUES ('456-dais-01', 'Datab�zov� a informacn� syst�my');
INSERT INTO kurz VALUES ('456-tzd-01', 'Teorie zpracov�n� dat');
INSERT INTO kurz VALUES ('450-apps-01', 'Architektury poc�tacu a paraleln�ch syst�mu');
INSERT INTO kurz VALUES ('457-pj-02', 'Programov�n� 2');
INSERT INTO kurz VALUES ('458-pj-01', 'Programov�n� 1');

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