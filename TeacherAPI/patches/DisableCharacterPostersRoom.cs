﻿using System.Linq;
using TeacherAPI.utils;

namespace TeacherAPI.patches
{
    //[HarmonyPatch(typeof(CharacterPostersRoomFunction), nameof(CharacterPostersRoomFunction.Build))]
    // Patch disabled because it misses the Poster of the Teachers
    internal class CharacterPostersRoomPatch
    {
        internal static bool Prefix(LevelBuilder builder)
        {
            var charactersThatDisablesSpawn = (
                from x in builder.Ec.npcsToSpawn
                where x.IsTeacher() && ((Teacher)x).disableNpcs
                select (Teacher)x
            );
            charactersThatDisablesSpawn.Print("Characters that disable NPC spawn", TeacherPlugin.Log);
            if (charactersThatDisablesSpawn.Count() > 0)
            {
                return false;
            }
            return true;
        }
    }
}
