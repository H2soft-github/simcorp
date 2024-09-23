using WordsCounterApp;

Executor.ShowAppInfo();
var stats = await Executor.Process(Executor.PrepareFilesPaths());
Executor.DisplaResult(stats);