using System;
using System.IO;
using Components;
using Newtonsoft.Json;

namespace Systems
{
    public class FileDeserializer
    {
        public static PathComponent DeserializeFile(string pathToJson)
        {
            PathComponent pathComponent; try
            {
                using (StreamReader file = File.OpenText(pathToJson))
                {
                    var serializer = new JsonSerializer();
                    pathComponent = (PathComponent)serializer.Deserialize(file, typeof(PathComponent));

                }
            }
            catch (Exception e)
            {
                throw new JsonSerializationException(
                    "Check the existence of file and correctness of json data.",
                    e);
            }

            return pathComponent;
        }
    }
}
