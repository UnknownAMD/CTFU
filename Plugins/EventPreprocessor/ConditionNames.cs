using System.Collections.Generic;

namespace EventPreprocessor
{
    public class ConditionNames
    {
        public static Dictionary<int, Dictionary<int, string>> ConditionSystemDict =
               new Dictionary<int, Dictionary<int, string>>()
               {
                    {
                         -7, new Dictionary<int, string>()
                         {
                              {-6, "PlayerKeyDown"},
                              {-5, "PlayerDied"},
                              {-4, "PlayerKeyPressed"},
                              {-3, "NumberOfLives"},
                              {-2, "CompareScore"},
                              {-1, "PLAYERPLAYING"}
                         }
                    },

                    {
                         -6, new Dictionary<int, string>()
                         {
                              {-12, "MouseWheelDown"},
                              {-11, "MouseWheelUp"},
                              {-10, "MouseVisible"},
                              {-9, "AnyKeyPressed"},
                              {-8, "WhileMousePressed"},
                              {-7, "ObjectClicked"},
                              {-6, "MouseClickedInZone"},
                              {-5, "Mouse Clicked"},
                              {-4, "Mouse OnObject"},
                              {-3, "Mouse InZone"},
                              {-2, "Key Down"},
                              {-1, "Key Pressed"}
                         }
                    },
                    {
                         -5, new Dictionary<int, string>()
                         {
                              {-23, "PickObjectsInLine"},
                              {-22, "PickFlagOff"},
                              {-21, "PickFlagOn"},
                              {-20, "PickAlterableValue"},
                              {-19, "PickFromFixed"},
                              {-18, "PickObjectsInZone"},
                              {-17, "PickRandomObject"},
                              {-16, "PickRandomObjectInZone"},
                              {-15, "CompareObjectCount"},
                              {-14, "AllObjectsInZone"},
                              {-13, "NoAllObjectsInZone"},
                              {-12, "PickFlagOff"},
                              {-11, "PickFlagOn"},
                              {-8, "PickAlterableValue"},
                              {-7, "PickFromFixed"},
                              {-6, "PickObjectsInZone"},
                              {-5, "PickRandomObject"},
                              {-4, "PickRandomObjectInZoneOld"},
                              {-3, "CompareObjectCount"},
                              {-2, "AllObjectsInZone"},
                              {-1, "NoAllObjectsInZone"}
                         }
                    },
                    {
                         -4, new Dictionary<int, string>()
                         {
                              {-8, "Every"},
                              {-7, "Timer Equals"},
                              {-6, "On Timer Event"},
                              {-5, "Compare Away Time"},
                              {-4, "Every"},
                              {-3, "Timer Equals"},
                              {-2, "Timer Less"},
                              {-1, "Timer Greater"}
                         }
                    },
                    {
                         -3, new Dictionary<int, string>()
                         {
                              {-10, "Frame Saved"},
                              {-9, "Frame Loaded"},
                              {-8, "Application Resumed"},
                              {-7, "Vsync Enabled"},
                              {-6, "Is Ladder"},
                              {-5, "Is Obstacle"},
                              {-4, "End Of Application"},
                              {-3, "LEVEL"},
                              {-2, "End Of Frame"},
                              {-1, "Start Of Frame"}
                         }
                    },
                    {
                         -2, new Dictionary<int, string>()
                         {
                              {-9, "ChannelPaused"},
                              {-8, "ChannelNotPlaying"},
                              {-7, "MusicPaused"},
                              {-6, "SamplePaused"},
                              {-5, "MusicFinished"},
                              {-4, "NoMusicPlaying"},
                              {-3, "NoSamplesPlaying"},
                              {-2, "SpecificMusicNotPlaying"},
                              {-1, "SampleNotPlaying"}
                         }
                    },
                    {
                         -1, new Dictionary<int, string>()
                         {
                              {-40, "RunningAs"},
                              {-39, "CompareGlobalValueDoubleGreater"},
                              {-38, "CompareGlobalValueDoubleGreaterEqual"},
                              {-37, "CompareGlobalValueDoubleLess"},
                              {-36, "CompareGlobalValueDoubleLessEqual"},
                              {-35, "CompareGlobalValueDoubleNotEqual"},
                              {-34, "CompareGlobalValueDoubleEqual"},
                              {-33, "CompareGlobalValueIntGreater"},
                              {-32, "CompareGlobalValueIntGreaterEqual"},
                              {-31, "CompareGlobalValueIntLess"},
                              {-30, "CompareGlobalValueIntLessEqual"},
                              {-29, "CompareGlobalValueIntNotEqual"},
                              {-28, "CompareGlobalValueIntEqual"},
                              {-27, "ElseIf"},
                              {-26, "Chance"},
                              {-25, "OrLogical"},
                              {-24, "OrFiltered"},
                              {-23, "OnGroupActivation"},
                              {-22, "ClipboardDataAvailable"},
                              {-21, "CloseSelected"},
                              {-20, "CompareGlobalString"},
                              {-19, "MenuVisible"},
                              {-18, "MenuEnabled"},
                              {-17, "MenuChecked"},
                              {-16, "OnLoop"},
                              {-15, "FilesDropped"},
                              {-14, "MenuSelected"},
                              {-13, "RECORDKEY"},
                              {-12, "GroupActivated"},
                              {-11, "GroupEnd"},
                              {-10, "NewGroup"},
                              {-9, "Remark"},
                              {-8, "CompareGlobalValue"},
                              {-7, "NotAlways"},
                              {-6, "Once"},
                              {-5, "Repeat"},
                              {-4, "RestrictFor"},
                              {-3, "Compare"},
                              {-2, "Never"},
                              {-1, "Always"}
                         }
                    },
                    {
                         2, new Dictionary<int, string>()
                         {
                              {-81, "ObjectClicked"},
                              {-25, "FlagOn"},
                              {-4, "Overlapping"},
                              {-24, "FlagOff"},
                              {-14, "UNK3"},
                              {-13, "UNK2"},
                              {-12, "UNK"},
                              {-42, "AlterableValue"},
                              {-2, "AnimationOver"}
                         }
                    },
                    {
                         4, new Dictionary<int, string>()
                         {
                              {-83, "AnswerMatches"},
                              {-82, "AnswerFalse"},
                              {-81, "AnswerTrue"}
                         }
                    },
                    {
                         7, new Dictionary<int, string>()
                         {
                              {-81, "CompareCounter"}
                         }
                    },
                    {
                         9, new Dictionary<int, string>()
                         {
                              {-84, "SubApplicationPaused"},
                              {-83, "SubApplicationVisible"},
                              {-82, "SubApplicationFinished"},
                              {-81, "SubApplicationFrameChanged"}
                         }
                    },
                    {
                         35, new Dictionary<int, string>()
                         {
                              {-85, "IsFocused"},
                              {22, "GetTextColor"},
                              {80, "GetText"}

                         }
                    }
               };
    }
}