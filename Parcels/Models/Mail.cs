using System.Collections.Generic;

namespace Parcels.Models
{
  public class Mail
  {
    public string Description { get; set; }
    public int Weight { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Volume { get; set; }
    public int CostToShip { get; set; }
    private static List<Mail> _instances = new List<Mail> {};

    public Mail (string description, int weight, int length, int width, int height)
    {
      Description = description;
      Weight = weight;
      Length = length;
      Width = width;
      Height = height;
      Volume = 0;
      CostToShip = 0;
      _instances.Add(this);
    }

    public static List<Mail> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public void GetVolume(int length, int width, int height)
    {
      this.Volume = length * width * height;
    }

    public void GetCost(int weight, int length, int width, int height)
    {
      if ((length * width * height)/139 > weight * 3) {
        this.CostToShip = (length * width * height)/139;
      }
      else
      {
        this.CostToShip = weight * 3;
      }
    }

  }
}