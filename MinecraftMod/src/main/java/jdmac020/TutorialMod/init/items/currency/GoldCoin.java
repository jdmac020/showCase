package jdmac020.TutorialMod.init.items.currency;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.item.Item;

public class GoldCoin extends Item 
{
	public GoldCoin(String name)
	{
		super();
		setUnlocalizedName(name);
		setRegistryName(name);
		setCreativeTab(TutorialTabs.tabTutorialItems);
	}
}
