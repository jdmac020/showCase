package jdmac020.TutorialMod.init.items.materials;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.item.Item;

public class CopperIngot extends Item 
{
	public CopperIngot(String name)
	{
		super();
		setUnlocalizedName(name);
		setRegistryName(name);
		setCreativeTab(TutorialTabs.tabTutorialItems);
	}
}
