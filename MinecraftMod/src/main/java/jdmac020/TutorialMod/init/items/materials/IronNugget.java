package jdmac020.TutorialMod.init.items.materials;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.item.Item;

public class IronNugget extends Item 
{
	public IronNugget(String name)
	{
		super();
		setUnlocalizedName(name);
		setRegistryName(name);
		setCreativeTab(TutorialTabs.tabTutorialItems);
	}
}
