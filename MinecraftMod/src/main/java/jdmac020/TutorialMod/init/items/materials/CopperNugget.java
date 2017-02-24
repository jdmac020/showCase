package jdmac020.TutorialMod.init.items.materials;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.item.Item;

public class CopperNugget extends Item 
{
	public CopperNugget(String name)
	{
		super();
		setUnlocalizedName(name);
		setRegistryName(name);
		setCreativeTab(TutorialTabs.tabTutorialItems);
	}
}
