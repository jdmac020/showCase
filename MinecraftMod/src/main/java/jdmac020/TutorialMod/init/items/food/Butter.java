package jdmac020.TutorialMod.init.items.food;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.item.ItemFood;

public class Butter extends ItemFood
{

	public Butter(int amount, float saturation, boolean isWolfFood, String name) 
	{
		super(amount, saturation, isWolfFood);
		setUnlocalizedName(name);
		setRegistryName(name);
		setCreativeTab(TutorialTabs.tabTutorialFood);
	}

}
