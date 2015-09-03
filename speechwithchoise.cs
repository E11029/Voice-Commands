#region Speech recognition with Choices and GrammarBuilder.Append
        static void SpeechRecognitionWithChoices()
        {
            _recognizer = new SpeechRecognitionEngine();
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append("I"); // add "I"
            grammarBuilder.Append(new Choices("left", "right","click","aluththavum","ariyavum","adi","exit","double")); // load "like" & "dislike"
           // grammarBuilder.Append(new Choices("click","done")); // add animals
            _recognizer.LoadGrammar(new Grammar(grammarBuilder)); // load grammar
            _recognizer.SpeechRecognized += speechRecognitionWithChoices_SpeechRecognized;
            _recognizer.SetInputToDefaultAudioDevice(); // set input to default audio device
            _recognizer.RecognizeAsync(RecognizeMode.Multiple); // recognize speech
        }

        static void speechRecognitionWithChoices_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
           // Console.WriteLine("your command : " + e.Result.Words[1].Text);

            if (String.Equals(e.Result.Words[1].Text, "exit", StringComparison.Ordinal))
            {
                Console.WriteLine("ok");
                manualResetEvent.Set();
                return;
            }
            if (String.Equals(e.Result.Words[1].Text, "right", StringComparison.Ordinal))
            {
                RightClick();
            }
            if (String.Equals(e.Result.Words[1].Text, "left", StringComparison.Ordinal))
            {
                LeftClick();
            }
            if (String.Equals(e.Result.Words[1].Text, "double", StringComparison.Ordinal))
            {
                LeftClick();
                LeftClick();
            }



        }
        #endregion
