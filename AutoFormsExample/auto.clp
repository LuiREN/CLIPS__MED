
;;;======================================================
;;;   Automotive Expert System
;;;
;;;     This expert system diagnoses some simple
;;;     problems with a car.
;;;
;;;     CLIPS Version 6.3 Example
;;;
;;;     For use with the Auto Demo Example
;;;======================================================

;;;*****************
;;;* Configuration *
;;;*****************
   
(defglobal ?*target* = gui) ; console, cgi, or gui

;;; ***************************
;;; * DEFTEMPLATES & DEFFACTS *
;;; ***************************

(deftemplate MAIN::text-for-id
   (slot id)
   (slot text))

(deftemplate UI-state
   (slot id (default-dynamic (gensym*)))
   (slot display)
   (slot relation-asserted (default none))
   (slot response (default none))
   (multislot valid-answers)
   (multislot display-answers)
   (slot state (default middle)))
   
;;;***************************
;;;* DEFFUNCTION DEFINITIONS *
;;;***************************

(deffunction MAIN::find-text-for-id (?id)
   ;; Search for the text-for-id fact
   ;; with the same id as ?id
   (bind ?fact
      (find-fact ((?f text-for-id))
                  (eq ?f:id ?id)))
   (if ?fact
      then
      (fact-slot-value (nth$ 1 ?fact) text)
      else
      ?id))
      
(deffunction MAIN::translate-av (?values)
   ;; Create the return value
   (bind ?result (create$))
   ;; Iterate over each of the allowed-values
   (progn$ (?v ?values)
      ;; Find the associated text-for-id fact
      (bind ?nv
         (find-text-for-id ?v))
      ;; Add the text to the return value
      (bind ?result (create$ ?result ?nv)))
   ;; Return the return value
   ?result)

(deffunction MAIN::replace-spaces (?str)
   (bind ?len (str-length ?str))
   (bind ?i (str-index " " ?str))
   (while (neq ?i FALSE)
      (bind ?str (str-cat (sub-string 1 (- ?i 1) ?str) "-" (sub-string (+ ?i 1) ?len ?str)))
      (bind ?i (str-index " " ?str)))
   ?str)

(deffunction MAIN::sym-cat-multifield (?values)
   (bind ?rv (create$))
   (progn$ (?v ?values)
      (bind ?rv (create$ ?rv (sym-cat (replace-spaces ?v)))))
   ?rv)

(deffunction MAIN::multifield-to-delimited-string (?mv ?delimiter)
   (bind ?rv "")
   (bind ?first TRUE)
   (progn$ (?v ?mv)
      (if ?first
         then
         (bind ?first FALSE)
         (bind ?rv (str-cat ?v))
         else
         (bind ?rv (str-cat ?rv ?delimiter ?v))))
   ?rv)

;;;*****************
;;;* STATE METHODS *
;;;*****************
      
;;; Console target
   
(defmethod handle-state ((?state SYMBOL (eq ?state greeting))
                         (?target SYMBOL (eq ?target console))
                         (?display LEXEME)
                         (?relation-asserted SYMBOL)
                         (?valid-answers MULTIFIELD))
   (printout t ?display crlf)
   (str-assert (str-cat "(" ?relation-asserted " " yes ")")))

(defmethod handle-state ((?state SYMBOL (eq ?state interview))
                         (?target SYMBOL (eq ?target console))
                         (?question LEXEME)
                         (?relation-asserted SYMBOL)
                         (?response PRIMITIVE) ; default
                         (?valid-answers MULTIFIELD)
                         (?display-answers MULTIFIELD))
   (bind ?display-answers (sym-cat-multifield ?display-answers))
   (format t "%s " ?question)
   (printout t ?display-answers " ")
   (bind ?answer (read))
   (if (lexemep ?answer) 
       then (bind ?answer (lowcase ?answer)))
   (while (not (member$ ?answer ?display-answers)) do
      (format t "%s " ?question)
      (printout t ?display-answers " ")
      (bind ?answer (read))
      (if (lexemep ?answer) 
          then (bind ?answer (lowcase ?answer))))
   (bind ?pos (member$ ?answer ?display-answers))
   (bind ?answer (nth$ ?pos ?valid-answers))
   (str-assert (str-cat "(" ?relation-asserted " " ?answer ")")))

(defmethod handle-state ((?state SYMBOL (eq ?state conclusion))
                         (?target SYMBOL (eq ?target console))
                         (?display LEXEME))
   (assert (conclusion))
   (printout t ?display crlf)
   (halt))

;;; CGI target

(defmethod handle-state ((?state SYMBOL (eq ?state greeting))
                         (?target SYMBOL (eq ?target cgi))
                         (?display LEXEME)
                         (?relation-asserted SYMBOL)
                         (?valid-answers MULTIFIELD))
   (printout t "state=greeting" crlf)
   (printout t "display=" ?display crlf)
   (printout t "variable=greeting" crlf)
   (printout t "validAnswers=yes" crlf)
   (printout t "displayAnswers=yes" crlf)
   (printout t "prevLabel=" (find-text-for-id Prev) crlf)
   (printout t "nextLabel=" (find-text-for-id Next) crlf)
   (printout t "restartLabel=" (find-text-for-id Restart) crlf)
   (printout t "autoDemoLabel=" (find-text-for-id AutoDemo) crlf)
   (halt))

(defmethod handle-state ((?state SYMBOL (eq ?state interview))
                         (?target SYMBOL (eq ?target cgi))
                         (?message LEXEME)
                         (?relation-asserted SYMBOL)
                         (?response PRIMITIVE)
                         (?valid-answers MULTIFIELD)
                         (?display-answers MULTIFIELD))
   (printout t "state=interview" crlf)
   (printout t "display=" ?message crlf)  
   (printout t "variable=" ?relation-asserted crlf)
   (printout t "validAnswers=" (multifield-to-delimited-string ?valid-answers ":") crlf)
   (printout t "displayAnswers=" (multifield-to-delimited-string ?display-answers ":") crlf) 
   (printout t "prevLabel=" (find-text-for-id Prev) crlf)
   (printout t "nextLabel=" (find-text-for-id Next) crlf)
   (printout t "restartLabel=" (find-text-for-id Restart) crlf)
   (printout t "autoDemoLabel=" (find-text-for-id AutoDemo) crlf)
   (halt))

(defmethod handle-state ((?state SYMBOL (eq ?state conclusion))
                         (?target SYMBOL (eq ?target cgi))
                         (?display LEXEME))
   (printout t "state=conclusion" crlf)
   (printout t "display=" ?display crlf)
   (printout t "prevLabel=" (find-text-for-id Prev) crlf)
   (printout t "nextLabel=" (find-text-for-id Next) crlf)
   (printout t "restartLabel=" (find-text-for-id Restart) crlf)
   (printout t "autoDemoLabel=" (find-text-for-id AutoDemo) crlf)
   (assert (conclusion))
   (halt))

;;; GUI target (iOS and JNI)

(defmethod handle-state ((?state SYMBOL (eq ?state greeting))
                         (?target SYMBOL (eq ?target gui))
                         (?message LEXEME)
                         (?relation-asserted SYMBOL)
                         (?valid-answers MULTIFIELD))
   (assert (UI-state (display ?message)
                     (relation-asserted greeting)
                     (state ?state)
                     (valid-answers yes)
                     (display-answers yes)))
   (halt))

(defmethod handle-state ((?state SYMBOL (eq ?state interview))
                         (?target SYMBOL (eq ?target gui))
                         (?message LEXEME)
                         (?relation-asserted SYMBOL)
                         (?response PRIMITIVE)
                         (?valid-answers MULTIFIELD)
                         (?display-answers MULTIFIELD))
   (assert (UI-state (display ?message)
                     (relation-asserted ?relation-asserted)
                     (state ?state)
                     (response ?response)
                     (valid-answers ?valid-answers)
                     (display-answers ?display-answers)))
   (halt))
 
(defmethod handle-state ((?state SYMBOL (eq ?state conclusion))
                         (?target SYMBOL (eq ?target gui))
                         (?display LEXEME))
   (assert (UI-state (display ?display)
                     (state ?state)
                     (valid-answers)
                     (display-answers)))
   (assert (conclusion))
   (halt))

;;;****************
;;;* STARTUP RULE *
;;;****************

(defrule system-banner ""
  (not (greeting yes))
  =>
  (handle-state greeting
                ?*target*
                (find-text-for-id WelcomeMessage)
                greeting
                (create$)))
  
;;;***************
;;;* QUERY RULES *
;;;***************

(defrule determine-fever-state ""
  (greeting yes)
  (not (has-fever ?))
  =>
  (bind ?answers (create$ no yes))
  (handle-state interview ?*target* (find-text-for-id FeverQuestion) has-fever (nth$ 1 ?answers) ?answers (translate-av ?answers)))

(defrule determine-headache-state ""
  (not (has-headache ?))
  (not (conclusion))
  =>
  (bind ?answers (create$ no yes))
  (handle-state interview ?*target* (find-text-for-id HeadacheQuestion) has-headache (nth$ 1 ?answers) ?answers (translate-av ?answers)))

(defrule determine-nausea-state ""
  (not (has-nausea ?))
  (not (conclusion))
  =>
  (bind ?answers (create$ no yes))
  (handle-state interview ?*target* (find-text-for-id NauseaQuestion) has-nausea (nth$ 1 ?answers) ?answers (translate-av ?answers)))

(defrule determine-fatigue-state ""
  (not (has-fatigue ?))
  (not (conclusion))
  =>
  (bind ?answers (create$ no yes))
  (handle-state interview ?*target* (find-text-for-id FatigueQuestion) has-fatigue (nth$ 1 ?answers) ?answers (translate-av ?answers)))

(defrule determine-cough-state ""
  (not (has-cough ?))
  (not (conclusion))
  =>
  (bind ?answers (create$ no yes))
  (handle-state interview ?*target* (find-text-for-id CoughQuestion) has-cough (nth$ 1 ?answers) ?answers (translate-av ?answers)))

(defrule determine-sore-throat-state ""
  (not (has-sore-throat ?))
  (not (conclusion))
  =>
  (bind ?answers (create$ no yes))
  (handle-state interview ?*target* (find-text-for-id SoreThroatQuestion) has-sore-throat (nth$ 1 ?answers) ?answers (translate-av ?answers)))

(defrule determine-diarrhea-state ""
  (not (has-diarrhea ?))
  (not (conclusion))
  =>
  (bind ?answers (create$ no yes))
  (handle-state interview ?*target* (find-text-for-id DiarrheaQuestion) has-diarrhea (nth$ 1 ?answers) ?answers (translate-av ?answers)))

(defrule determine-rash-state ""
  (not (has-rash ?))
  (not (conclusion))
  =>
  (bind ?answers (create$ no yes))
  (handle-state interview ?*target* (find-text-for-id RashQuestion) has-rash (nth$ 1 ?answers) ?answers (translate-av ?answers)))


;;;****************
;;;* HEALTH RULES *
;;;****************

(defrule possible-flu-state ""
  (declare (salience 10))
  (or (and (has-fever yes) (has-fatigue yes))
      (and (has-fever yes) (has-cough yes)))
  =>
  (handle-state conclusion ?*target* (find-text-for-id PossibleFluState)))

(defrule possible-migraine-state ""
  (declare (salience 10))
  (has-headache yes)
  (has-nausea yes)
  =>
  (handle-state conclusion ?*target* (find-text-for-id PossibleMigraineState)))

(defrule fatigue-state ""
  (declare (salience 5))
  (has-fatigue yes)
  (not (has-fever yes))
  (not (has-headache yes))
  (not (has-nausea yes))
  (not (has-cough yes))
  (not (has-sore-throat yes))
  (not (has-diarrhea yes))
  (not (has-rash yes))
  (not (has-muscle-pain yes))
  (not (has-chest-pain yes))
  =>
  (handle-state conclusion ?*target* (find-text-for-id FatigueState)))

(defrule possible-sore-throat-state ""
  (declare (salience 5))
  (has-sore-throat yes)
  (not (has-fever yes))
  (not (has-cough yes))
  =>
  (handle-state conclusion ?*target* (find-text-for-id PossibleSoreThroatState)))

(defrule possible-stomach-flu-state ""
  (declare (salience 5))
  (has-diarrhea yes)
  (has-nausea yes)
  =>
  (handle-state conclusion ?*target* (find-text-for-id PossibleStomachFluState)))

(defrule possible-allergy-state ""
  (declare (salience 5))
  (has-rash yes)
  (not (has-fever yes))
  (not (has-muscle-pain yes))
  (not (has-chest-pain yes))
  =>
  (handle-state conclusion ?*target* (find-text-for-id PossibleAllergy)))

(defrule possible-musculoskeletal-issue ""
  (declare (salience 5))
  (or (has-muscle-pain yes) (has-chest-pain yes))
  (not (has-fever yes))
  (not (has-headache yes))
  (not (has-nausea yes))
  (not (has-cough yes))
  (not (has-sore-throat yes))
  (not (has-diarrhea yes))
  (not (has-rash yes))
  =>
  (handle-state conclusion ?*target* (find-text-for-id PossibleMusculoskeletalIssue)))

; Правило для здорового состояния
(defrule healthy-state ""
  (declare (salience -10))
  (not (has-fever yes))
  (not (has-headache yes))
  (not (has-nausea yes))
  (not (has-fatigue yes))
  (not (has-cough yes))
  (not (has-sore-throat yes))
  (not (has-diarrhea yes))
  (not (has-rash yes))
  (not (has-muscle-pain yes))
  (not (has-chest-pain yes))
  (not (conclusion))
  =>
  (handle-state conclusion ?*target* (find-text-for-id HealthyState)))

; Общая рекомендация
(defrule see-a-doctor ""
  (declare (salience -20))
  (not (conclusion))
  =>
  (handle-state conclusion ?*target* (find-text-for-id SeeADoctorAdvice)))
  
